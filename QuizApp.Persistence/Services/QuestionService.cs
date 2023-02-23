using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Features.Question.Queries.GetQuestionList;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionWriteRepository _questionWriteRepository;
    private readonly IQuestionReadRepository _questionReadRepository;
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionWriteRepository writeRepository, IMapper mapper, IQuestionReadRepository readRepository, IQuizService quizService)
    {
        _questionWriteRepository = writeRepository;
        _mapper = mapper;
        _questionReadRepository = readRepository;
        _quizService = quizService;
    }

    public async Task CreateQuestion(CreateQuestionCommand request)
    {
        await CheckQuestionLimitForQuiz(request.QuizId);
        var verifyResult = await VerifyOwnership(request.QuizId);
        if (verifyResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("quiz", "create question"));

        var mapped = _mapper.Map<Question>(request);
        await _questionWriteRepository.AddAsync(mapped);
        await _questionWriteRepository.SaveAsync();
    }

    public async Task DeleteQuestion(DeleteQuestionCommand request)
    {
        var verifyResult = await VerifyOwnership(request.Id);
        if (verifyResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("quiz", "delete question"));

        var question = await CheckIfQuestionExists(request.Id);
        _questionWriteRepository.Remove(question);
        await _questionWriteRepository.SaveAsync();
    }

    public async Task UpdateQuestion(UpdateQuestionCommand request)
    {
        var question = await CheckIfQuestionExists(request.Id);

        var verifyResult = await VerifyOwnership(question.QuizId);
        if (verifyResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("quiz", "update question"));

        var mapped = _mapper.Map(request, question);

        _questionWriteRepository.Update(mapped);
        await _questionWriteRepository.SaveAsync();
    }


    public async Task<List<QuestionInfoDto>> GetQuestionList(GetQuestionListQuery request)
    {
        var result = await _questionReadRepository.GetAll()
            .Where(p => p.QuizId == request.QuizId)
            .Select(p => new QuestionInfoDto()
            {
                QuestionId = p.Id,
                Title = p.Title,
                Descripton = p.Description
            })
            .ToListAsync();
        return result;
    }

    public async Task<string> GetQuizId(string questionId)
    {
        var question = await CheckIfQuestionExists(questionId);
        return question.QuizId;
    }

    private async Task CheckQuestionLimitForQuiz(string quizId)
    {
        var questionCount = await _questionReadRepository.GetAll(false)
            .Where(p => p.QuizId == quizId)
            .CountAsync();
        if (questionCount > 20)
            throw new BusinessException(Messages.MaximumQuestionCountForQuiz);
    }

    private async Task<Question> CheckIfQuestionExists(string id)
    {
        var result = await _questionReadRepository.GetByIdAsync(id);
        if (result == null)
            throw new NotFoundException(Messages.NotFound("Question"));
        return result;
    }

    private async Task<bool> VerifyOwnership(string quizId)
    {
        return await _quizService.CheckOwnerShip(quizId);
    }
}

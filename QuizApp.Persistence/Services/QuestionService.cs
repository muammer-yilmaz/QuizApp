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
    private readonly IMapper _mapper;

    public QuestionService(IQuestionWriteRepository writeRepository, IMapper mapper, IQuestionReadRepository readRepository)
    {
        _questionWriteRepository = writeRepository;
        _mapper = mapper;
        _questionReadRepository = readRepository;
    }

    public async Task CreateQuestion(CreateQuestionCommand request)
    {
        var mapped = _mapper.Map<Question>(request);
        await _questionWriteRepository.AddAsync(mapped);
        await _questionWriteRepository.SaveAsync();
    }

    public async Task DeleteQuestion(DeleteQuestionCommand request)
    {
        await CheckIfQuestionExists(request.Id);
        await _questionWriteRepository.RemoveAsync(request.Id);
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

    public async Task UpdateQuestion(UpdateQuestionCommand request)
    {
        // TODO : Check ownership for Update
        var question = await CheckIfQuestionExists(request.Id);
        var mapped = _mapper.Map(request,question);
        _questionWriteRepository.Update(mapped);
        await _questionWriteRepository.SaveAsync();
    }

    private async Task<Question> CheckIfQuestionExists(string id)
    {
        var result = await _questionReadRepository.GetByIdAsync(id);
        if (result == null)
            throw new NotFoundException(Messages.NotFound("Question"));
        return result;
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
using QuizApp.Application.Features.Option.Commands.UpdateAnswer;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Features.Option.Queries.GetOptionList;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services;

public class OptionService : IOptionService
{
    private readonly IOptionWriteRepository _optionWriteRepository;
    private readonly IOptionReadRepository _optionReadRepository;
    private readonly IMapper _mapper;
    private readonly IQuestionService _questionService;
    private readonly IQuizService _quizService;

    public OptionService(IOptionWriteRepository writeRepository, IMapper mapper, IOptionReadRepository readRepository, IQuizService quizService, IQuestionService questionService)
    {
        _optionWriteRepository = writeRepository;
        _mapper = mapper;
        _optionReadRepository = readRepository;
        _quizService = quizService;
        _questionService = questionService;
    }

    public async Task CreateOption(CreateOptionCommand request)
    {
        if (request.Options.FindAll(x => x.IsAnswer == true).Count != 1)
            throw new BusinessException(Messages.OptionsCanHaveOnlyOneTrueAnswer);
       
        var ownerShipResult = await VerifyOwnerShip(request.QuestionId);
        if (ownerShipResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("question", "create option"));


        var mapped = _mapper.Map<List<Option>>(request.Options);
        await _optionWriteRepository.AddRangeAsync(mapped);
        await _optionWriteRepository.SaveAsync();
    }
    /// <summary>
    /// An Option can only be deleted if request sent from author of the quiz
    /// and also options true answer cant be deleted or a question only left with 2 option
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="AuthorizationException"></exception>
    /// <exception cref="BusinessException"></exception>
    public async Task DeleteOption(DeleteOptionCommand request)
    {
        // TODO : Later with different quiz types this method may need re-implement

        var option = await CheckIfOptionExists(request.Id);
        var ownerShipResult = await VerifyOwnerShip(option.QuestionId);

        if (ownerShipResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("question", "delete option"));
        if (option.IsAnswer == true)
            throw new BusinessException(Messages.OptionTrueAnswerDeletionNotAllowed);

        var optionCountForQuestion = await _optionReadRepository.GetAll()
            .Where(p => p.QuestionId == option.QuestionId)
            .CountAsync();

        if (optionCountForQuestion == 2)
            throw new BusinessException(Messages.MinimumOptionsForQuestionLimit);

        _optionWriteRepository.Remove(option);
        await _optionWriteRepository.SaveAsync();
    }

    public async Task UpdateOption(UpdateOptionCommand request)
    {
        var option = await CheckIfOptionExists(request.Id);
        var ownerShipResult = await VerifyOwnerShip(option.QuestionId);
        if (ownerShipResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("question", "update option"));

        var mapped = _mapper.Map(request, option);
        _optionWriteRepository.Update(mapped);
        await _optionWriteRepository.SaveAsync();
    }

    public async Task<List<OptionInfoDto>> GetOptionList(GetOptionListQuery request)
    {
        var ownerShipResult = await VerifyOwnerShip(request.QuestionId);
        if (ownerShipResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("question", "get options"));

        var result = await _optionReadRepository.GetAll()
            .Where(p => p.QuestionId == request.QuestionId)
            .Select(p => new OptionInfoDto
            {
                OptionId = p.Id,
                Descripton = p.Description,
                IsAnswer = p.IsAnswer
            }).ToListAsync();

        return result;
    }

    public async Task UpdateAnswer(UpdateAnswerCommand request)
    {
        var options = await _optionReadRepository.GetAll()
            .Where(x => x.Id == request.OldAnswerId || x.Id == request.NewAnswerId)
            .ToListAsync();

        if (options.Count != 2)
            throw new NotFoundException(Messages.NotFound("Option"));


        var ownerShipResult = await VerifyOwnerShip(options[0].QuestionId);
        if (ownerShipResult == false)
            throw new AuthorizationException(Messages.UnAuthorizedOperation("question", "update answer"));

        var oldOption = options.FirstOrDefault(x => x.Id == request.OldAnswerId)!;
        var newOption = options.FirstOrDefault(x => x.Id == request.NewAnswerId)!;

        oldOption.IsAnswer = oldOption.IsAnswer == true ? false : throw new BusinessException(Messages.OptionAlreadyFalse);
        newOption.IsAnswer = newOption.IsAnswer == false ? true : throw new BusinessException(Messages.OptionAlreadyTrue);

        await _optionWriteRepository.SaveAsync();
    }

    private async Task<Option> CheckIfOptionExists(string id)
    {
        var result = await _optionReadRepository.GetByIdAsync(id);
        if (result == null)
            throw new NotFoundException(Messages.NotFound("Option"));
        return result;
    }

    private async Task<bool> VerifyOwnerShip(string questionId)
    {
        var quizId = await _questionService.GetQuizId(questionId);
        return await _quizService.CheckOwnerShip(quizId);
    }


}

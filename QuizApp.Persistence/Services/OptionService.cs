using AutoMapper;
using Microsoft.AspNetCore.Http;
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
using System.Security.Claims;

namespace QuizApp.Persistence.Services;

public class OptionService : IOptionService
{
    private readonly IOptionWriteRepository _optionWriteRepository;
    private readonly IOptionReadRepository _optionReadRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;
    private readonly IQuestionService _questionService;
    private readonly IQuizService _quizService;

    public OptionService(IOptionWriteRepository writeRepository, IMapper mapper, IOptionReadRepository readRepository, IHttpContextAccessor httpContext, IQuizService quizService, IQuestionService questionService)
    {
        _optionWriteRepository = writeRepository;
        _mapper = mapper;
        _optionReadRepository = readRepository;
        _httpContext = httpContext;
        _quizService = quizService;
        _questionService = questionService;
    }

    public async Task CreateOption(CreateOptionCommand request)
    {
        if(request.Options.FindAll(x => x.IsAnswer == true).Count != 1)
        {
            throw new BusinessException(Messages.OptionsCanHaveOnlyOneTrueAnswer);
        }
        var mapped = _mapper.Map<List<Option>>(request.Options);
        await _optionWriteRepository.AddRangeAsync(mapped);
        await _optionWriteRepository.SaveAsync();
    }

    public async Task DeleteOption(DeleteOptionCommand request)
    {
        // TODO : Ownership , answer, option limit control
        await CheckIfOptionExists(request.Id);
        await _optionWriteRepository.RemoveAsync(request.Id);
        await _optionWriteRepository.SaveAsync();
    }

    public async Task UpdateOption(UpdateOptionCommand request)
    {
        var option = await CheckIfOptionExists(request.Id);
        var mapped = _mapper.Map(request,option);
        _optionWriteRepository.Update(mapped);
        await _optionWriteRepository.SaveAsync();
    }

    public async Task<List<OptionInfoDto>> GetOptionList(GetOptionListQuery request)
    {
        var userId = GetIdFromContext();
        var quizId = await _questionService.GetQuizId(request.QuestionId);
        await _quizService.CheckOwnerShip(quizId, userId);
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
        var options = await _optionReadRepository
            .GetAll()
            .Where(x => x.Id == request.OldAnswerId || x.Id == request.NewAnswerId)
            .ToListAsync();
        if(options.Count != 2)
        {
            throw new NotFoundException(Messages.NotFound("Option"));
        }

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
    private string GetIdFromContext()
    {
        var userId = _httpContext?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value;
        if (userId == null)
            throw new AuthorizationException(Messages.NoAuth);
        return userId;
    }



}

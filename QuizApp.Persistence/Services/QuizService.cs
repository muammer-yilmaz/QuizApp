using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using System.Security.Claims;

namespace QuizApp.Persistence.Services;

public class QuizService : IQuizService
{
    private readonly IQuizWriteRepository _writeRepository;
    private readonly IQuizReadRepository _readRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;

    public QuizService(IQuizWriteRepository quizWriteRepository, IMapper mapper, IHttpContextAccessor httpContext, IQuizReadRepository readRepository)
    {
        _writeRepository = quizWriteRepository;
        _mapper = mapper;
        _httpContext = httpContext;
        _readRepository = readRepository;
    }

    public async Task CreateQuizAsync(CreateQuizCommand request)
    {
        var mappedQuiz = _mapper.Map<Quiz>(request);
        mappedQuiz.UserId = GetIdFromContext();

        var result = await _writeRepository.AddAsync(mappedQuiz);
        if (!result)
            throw new Exception(Messages.AddFailure);
        await _writeRepository.SaveAsync();
    }

    public async Task DeleteQuizAsync(string id)
    {
        await _writeRepository.RemoveAsync(id);
        await _writeRepository.SaveAsync();
    }

    public async Task UpdateQuizAsync(UpdateQuizCommand request)
    {
        var quiz = await CheckIfQuizNotExists(request.Id);
        var mapped = _mapper.Map(request, quiz);
        _writeRepository.Update(mapped);
        await _writeRepository.SaveAsync();
    }

    public async Task<List<Quiz>> GetAllQuizzesAsync()
    {
        var query = _readRepository.GetAll(false);
        return await query.ToListAsync();
    }

    public async Task<GetAllQuizzesQueryResponse> GetAllQuizzesAsync(PaginationRequestDto request)
    {
        var result = await _readRepository.GetAll(false)
            .Skip((request.Page - 1) * (int)request.PageSize)
            .Take((int)request.PageSize)
            .ToListAsync();
        var mapped = _mapper.Map<List<QuizInfoDto>>(result);
        var totalCount = await _readRepository.Table.CountAsync();
        var totalPages = Math.Ceiling(totalCount / (double)request.PageSize);

        GetAllQuizzesQueryResponse response = new()
        {
            Quizzes = new()
            {
                Records = mapped,
                Page = request.Page,
                PageSize = (int)request.PageSize,
                TotalPages = (int)totalPages
            }
        };
        return response;
    }

    public async Task<GetAllQuizzesQueryResponse> SearchQuizzes(string searchText, PaginationRequestDto pagination)
    {
        var result = await _readRepository.GetAll(false)
            .Where(p => p.Title.IndexOf(searchText) >= 0)
            .Skip((pagination.Page - 1) * (int)pagination.PageSize)
            .Take((int)pagination.PageSize)
            .ToListAsync();
        var mapped = _mapper.Map<List<QuizInfoDto>>(result);
        var totalCount = await _readRepository.Table.Where(p => p.Title.IndexOf(searchText) >= 0).CountAsync();
        var totalPages = Math.Ceiling(totalCount / (double)pagination.PageSize);

        GetAllQuizzesQueryResponse response = new()
        {
            Quizzes = new()
            {
                Records = mapped,
                Page = pagination.Page,
                PageSize = (int)pagination.PageSize,
                TotalPages = (int)totalPages
            }
        };
        return response;
    }

    public async Task<QuizDetailsDto> GetQuizByIdAsync(string id)
    {
        var query = _readRepository.GetWhere(p => p.Id == id);

        var result = await query
            .Include(p => p.Category)
            .Include(p => p.Questions)
            .ThenInclude(p => p.Options).FirstOrDefaultAsync();

        var mapped = _mapper.Map<QuizDetailsDto>(result);
        mapped.CategoryName = result?.Category?.CategoryName;
        return mapped;
    }

    private async Task<Quiz> CheckIfQuizNotExists(string quizId)
    {
        var result = await _readRepository.GetByIdAsync(quizId);
        if (result == null)
            throw new NotFoundException(Messages.NotFound("Quiz"));
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


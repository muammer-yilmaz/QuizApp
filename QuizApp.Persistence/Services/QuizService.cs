using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes;
using QuizApp.Application.Features.Quiz.Queries.GetUserQuizzes;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using System.Security.Claims;

namespace QuizApp.Persistence.Services;

public class QuizService : IQuizService
{
    private readonly IQuizWriteRepository _quizWriteRepository;
    private readonly IQuizReadRepository _quizReadRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;

    public QuizService(IQuizWriteRepository quizWriteRepository, IMapper mapper, IHttpContextAccessor httpContext, IQuizReadRepository quizReadRepository)
    {
        _quizWriteRepository = quizWriteRepository;
        _mapper = mapper;
        _httpContext = httpContext;
        _quizReadRepository = quizReadRepository;
    }

    public async Task<string> CreateQuizAsync(CreateQuizCommand request)
    {
        var mappedQuiz = _mapper.Map<Quiz>(request);
        mappedQuiz.UserId = GetIdFromContext();

        // TODO : Check score later
        mappedQuiz.Score = 100;
        mappedQuiz.Id = Guid.NewGuid().ToString();

        var result = await _quizWriteRepository.AddAsync(mappedQuiz);
        if (!result)
            throw new Exception(Messages.AddFailure);
        await _quizWriteRepository.SaveAsync();

        return mappedQuiz.Id;
    }

    public async Task DeleteQuizAsync(string id)
    {
        var quiz = await CheckIfQuizExists(id);
        var userId = GetIdFromContext();
        if (quiz.UserId != userId)
        {
            throw new BusinessException(Messages.UnAuthorizedOperation("quiz", "delete"));
        }
        _quizWriteRepository.Remove(quiz);
        await _quizWriteRepository.SaveAsync();
    }

    public async Task UpdateQuizAsync(UpdateQuizCommand request)
    {
        var quiz = await CheckIfQuizExists(request.Id);
        var userId = GetIdFromContext();
        if (quiz.UserId != userId)
        {
            throw new BusinessException(Messages.UnAuthorizedOperation("quiz", "update"));
        }
        var mapped = _mapper.Map(request, quiz);
        _quizWriteRepository.Update(mapped);
        await _quizWriteRepository.SaveAsync();
    }

    public async Task<GetAllQuizzesQueryResponse> GetAllQuizzesAsync(PaginationRequestDto request)
    {
        var result = await _quizReadRepository.GetAll(false)
            .Include(p => p.Category)
            .Skip((request.Page - 1) * (int)request.PageSize)
            .Take((int)request.PageSize)
            .Select(p => new QuizInfoDto
            {
                Description = p.Description,
                QuizId = p.Id,
                Title = p.Title,
                CategoryName = p.Category.CategoryName
            })
            .ToListAsync();
        //var mapped = _mapper.Map<List<QuizInfoDto>>(result);
        var totalCount = await _quizReadRepository.Table.CountAsync();
        var totalPages = Math.Ceiling(totalCount / (double)request.PageSize);

        GetAllQuizzesQueryResponse response = new()
        {
            Quizzes = new()
            {
                Records = result,
                Page = request.Page,
                PageSize = (int)request.PageSize,
                TotalPages = (int)totalPages
            }
        };
        return response;
    }

    public async Task<GetAllQuizzesQueryResponse> SearchQuizzesAsync(string searchText, PaginationRequestDto pagination)
    {
        var result = await _quizReadRepository.GetAll(false)
            .Where(p => p.Title.IndexOf(searchText) >= 0)
            .Skip((pagination.Page - 1) * (int)pagination.PageSize)
            .Take((int)pagination.PageSize)
            .ToListAsync();
        var mapped = _mapper.Map<List<QuizInfoDto>>(result);
        var totalCount = await _quizReadRepository.Table.Where(p => p.Title.IndexOf(searchText) >= 0).CountAsync();
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

    public async Task<QuizDetailsDto> GetQuizDetailsAsync(string quizId)
    {

        var result = await _quizReadRepository.GetAll(false)
            .Where(p => p.Id == quizId)
            .Include(p => p.Category)
            .Include(p => p.Questions)
            .ThenInclude(p => p.Options)
            .OrderBy(p => p.CreatedDate)
            .FirstOrDefaultAsync();

        if (result == null)
            throw new NotFoundException(Messages.NotFound("Quiz"));

        // TODO : Check categoryname later

        var mapped = _mapper.Map<QuizDetailsDto>(result);
        mapped.CategoryName = result?.Category?.CategoryName;
        return mapped;
    }

    public async Task<List<QuizInfoDto>> GetUserQuizzesAsync()
    {
        var userId = GetIdFromContext();
        var result = await _quizReadRepository.GetWhere(p => p.UserId == userId, false)
            .Include(p => p.Category)
            .Select(p => new QuizInfoDto
            {
                QuizId = p.Id,
                Title = p.Description,
                Description = p.Description,
                CategoryName = p.Category.CategoryName
            })
            .ToListAsync();

        return result;
    }

    public async Task<bool> CheckOwnerShip(string quizId)
    {
        var userId = GetIdFromContext();
        var quiz = await CheckIfQuizExists(quizId);
        if (quiz.UserId != userId)
            return false;
        return true;
    }

    private async Task<Quiz> CheckIfQuizExists(string quizId)
    {
        var result = await _quizReadRepository.GetByIdAsync(quizId);
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

    public async Task<int> CalculateScore(string quizId)
    {
        // TODO : later score calculation will change
        var quiz = await CheckIfQuizExists(quizId);
        return quiz.Score;
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizApp.Persistence.Services;

public class QuizAttemptService : IQuizAttemptService
{
    private readonly IQuizAttemptWriteRepository _quizAttemptWriteRepository;
    private readonly IQuizAttemptReadRepository _quizAttemptReadRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public QuizAttemptService(IQuizAttemptWriteRepository quizAttemptWriteRepository, IQuizAttemptReadRepository quizAttemptReadRepository, IHttpContextAccessor httpContextAccessor)
    {
        _quizAttemptWriteRepository = quizAttemptWriteRepository;
        _quizAttemptReadRepository = quizAttemptReadRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task CreateAttempt(string quizId)
    {
        // TODO : check this fro timed quizzes later

        var attempt = await GetAttempt(quizId);
        if(attempt != null)
            return;

        var newAttempt = new QuizAttempt()
        {
            QuizId = quizId,
            UserId = GetIdFromContext()
        };

        await _quizAttemptWriteRepository.AddAsync(newAttempt);
        await _quizAttemptWriteRepository.SaveAsync();

    }

    public async Task UpdateAttempt(QuizFinishResultDto quizFinishResult)
    {
        // TODO : check for null checks and attempt not found later

        var attempt = await GetAttempt(quizFinishResult.QuizId);
        if (attempt == null)
            throw new NotFoundException(Messages.NotFound("Attempt"));

        attempt.IsFinished = true;
        attempt.QuizResultJson = JsonSerializer.Serialize(quizFinishResult);

        _quizAttemptWriteRepository.Update(attempt);
        
        await _quizAttemptWriteRepository.SaveAsync();

    }

    private async Task<QuizAttempt> GetAttempt(string quizId)
    {
        var userId = GetIdFromContext();
        var attempt = await _quizAttemptReadRepository.GetAll()
            .Where(p => p.QuizId == quizId)
            .Where(p => p.UserId == userId)
            .Where(p => p.IsFinished == false)
            .FirstOrDefaultAsync();
        return attempt;
    }

    private string GetIdFromContext()
    {
        var userId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value;
        if (userId == null)
            throw new AuthorizationException(Messages.NoAuth);
        return userId;
    }
}

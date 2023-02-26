using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using System.Security.Claims;

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
    public async Task CreateAttempt(CreateAttemptCommand request)
    {
        var userId = GetIdFromContext();
        var attempt = await _quizAttemptReadRepository.GetAll()
            .Where(p => p.QuizId == request.QuizId)
            .Where(p => p.UserId == userId)
            .FirstOrDefaultAsync();
        if(attempt != null)
            return;

        var newAttempt = new QuizAttempt()
        {
            QuizId = request.QuizId,
            UserId = userId
        };

        await _quizAttemptWriteRepository.AddAsync(newAttempt);
        await _quizAttemptWriteRepository.SaveAsync();

    }

    private string GetIdFromContext()
    {
        var userId = _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value;
        if (userId == null)
            throw new AuthorizationException(Messages.NoAuth);
        return userId;
    }
}

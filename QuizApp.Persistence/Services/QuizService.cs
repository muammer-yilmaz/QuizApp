using AutoMapper;
using Microsoft.AspNetCore.Http;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using QuizApp.Persistence.Repositories;
using System.Security.Claims;

namespace QuizApp.Persistence.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizWriteRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public QuizService(IQuizWriteRepository quizWriteRepository, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _repository = quizWriteRepository;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task CreateQuizAsync(CreateQuizCommand request)
        {
            var mappedQuiz = _mapper.Map<Quiz>(request);
            mappedQuiz.Id = Guid.NewGuid().ToString();
            mappedQuiz.UserId = _httpContext?.HttpContext?.User?.FindFirst(ClaimTypes.Authentication)?.Value;
            var result = await _repository.AddAsync(mappedQuiz);
            if (!result)
                throw new Exception(Messages.AddFailure);
            await _repository.SaveAsync();
        }
    }
}

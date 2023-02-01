using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Quiz.Commands.CreateQuiz;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services
{
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
            mappedQuiz.Id = Guid.NewGuid().ToString();
            mappedQuiz.UserId = request.UserId;
            //mappedQuiz.UserId = _httpContext?.HttpContext?.User?.FindFirst(ClaimTypes.Authentication)?.Value;
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

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            var query = _readRepository.GetAll(false);
            return await query.ToListAsync();
        }

        public async Task<QuizDetails> GetQuizByIdAsync(string id)
        {
            var query = _readRepository.GetWhere(p => p.Id == id);
            var result = await query.Include(p => p.Questions).ThenInclude(p => p.Options).FirstOrDefaultAsync();
            var mapped = _mapper.Map<QuizDetails>(result);
            return mapped;
        }
    }
}

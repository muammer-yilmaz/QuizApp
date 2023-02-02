using AutoMapper;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Question.Commands.CreateQuestion;
using QuizApp.Application.Features.Question.Commands.DeleteQuestion;
using QuizApp.Application.Features.Question.Commands.UpdateQuestion;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionWriteRepository _writeRepository;
        private readonly IQuestionReadRepository _readRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionWriteRepository writeRepository, IMapper mapper, IQuestionReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task CreateQuestion(CreateQuestionCommand request)
        {
            var mapped = _mapper.Map<Question>(request);
            await _writeRepository.AddAsync(mapped);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteQuestion(DeleteQuestionCommand request)
        {
            await CheckIfQuestionExists(request.Id);
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateQuestion(UpdateQuestionCommand request)
        {
            await CheckIfQuestionExists(request.Id);
            var mapped = _mapper.Map<Question>(request);
            _writeRepository.Update(mapped);
            await _writeRepository.SaveAsync();
        }

        private async Task CheckIfQuestionExists(string id)
        {
            var result = await _readRepository.GetSingleAsync(x => x.Id == id);
            if (result == null)
                throw new NotFoundException(Messages.NotFound("Question"));
        }
    }
}

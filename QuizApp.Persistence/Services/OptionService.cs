using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
using QuizApp.Application.Features.Option.Commands.UpdateAnswer;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionWriteRepository _writeRepository;
        private readonly IOptionReadRepository _readRepository;
        private readonly IMapper _mapper;

        public OptionService(IOptionWriteRepository writeRepository, IMapper mapper, IOptionReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task CreateOption(CreateOptionCommand request)
        {
            if(request.Options.FindAll(x => x.IsAnswer == true).Count != 1)
            {
                throw new BusinessException(Messages.OptionsCanHaveOnlyOneTrueAnswer);
            }
            var mapped = _mapper.Map<List<Option>>(request.Options);
            await _writeRepository.AddRangeAsync(mapped);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteOption(DeleteOptionCommand request)
        {
            await CheckIfOptionExists(request.Id);
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateOption(UpdateOptionCommand request)
        {
            var option = await CheckIfOptionExists(request.Id);
            var mapped = _mapper.Map(request,option);
            _writeRepository.Update(mapped);
            await _writeRepository.SaveAsync();
        }
        public async Task UpdateAnswer(UpdateAnswerCommand request)
        {
            var options = await _readRepository
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
            
            await _writeRepository.SaveAsync();
        }

        private async Task<Option> CheckIfOptionExists(string id)
        {
            var result = await _readRepository.GetByIdAsync(id);
            if (result == null)
                throw new NotFoundException(Messages.NotFound("Option"));
            return result;
        }
    
    }
}

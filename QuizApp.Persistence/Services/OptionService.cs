using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
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
            await CheckIfOptionCountMax(request.QuestionId);
            var mapped = _mapper.Map<Option>(request);
            await _writeRepository.AddAsync(mapped);
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
            //await CheckIfAllOptionsFalse(request.Id);
            var mapped = _mapper.Map(request,option);
            _writeRepository.Update(mapped);
            await _writeRepository.SaveAsync();
        }


        private async Task CheckIfOptionCountMax(string questionId)
        {
            var result = await _readRepository.GetWhere(x => x.QuestionId == questionId,false).ToListAsync();
            if (result.Count() == 4)
                throw new BusinessException(Messages.QuestionOptionMaxed);
        }

        private async Task<Option> CheckIfOptionExists(string id)
        {
            var result = await _readRepository.GetByIdAsync(id);
            if (result == null)
                throw new NotFoundException(Messages.NotFound("Option"));
            return result;
        }

        private async Task CheckIfAllOptionsFalse(string id)
        {
            var option = await _readRepository.GetWhere(x => x.Id == id,false).SingleOrDefaultAsync();
            var list = await _readRepository.GetWhere(x => x.QuestionId == option.QuestionId,false).ToListAsync();
            if (!list.Any(x => x.IsAnswer == true))
                throw new BusinessException(Messages.QuestionOptionAllFalse);
        }
    }
}

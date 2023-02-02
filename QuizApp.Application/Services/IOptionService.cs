using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
using QuizApp.Application.Features.Option.Commands.UpdateOption;

namespace QuizApp.Application.Services
{
    public interface IOptionService
    {
        public Task CreateOption(CreateOptionCommand request);
        public Task DeleteOption(DeleteOptionCommand request);
        public Task UpdateOption(UpdateOptionCommand request);
    }
}

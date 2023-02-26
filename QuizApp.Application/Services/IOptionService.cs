using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.Option.Commands.CreateOption;
using QuizApp.Application.Features.Option.Commands.DeleteOption;
using QuizApp.Application.Features.Option.Commands.UpdateAnswer;
using QuizApp.Application.Features.Option.Commands.UpdateOption;
using QuizApp.Application.Features.Option.Queries.GetOptionList;

namespace QuizApp.Application.Services;

public interface IOptionService
{
    public Task CreateOption(CreateOptionCommand request);
    public Task DeleteOption(DeleteOptionCommand request);
    public Task UpdateOption(UpdateOptionCommand request);
    public Task UpdateAnswer(UpdateAnswerCommand request);
    public Task<List<OptionOwnerInfoDto>> GetOptionListOwner(GetOptionListQuery request);
}

using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.CreateOption
{
    public sealed record CreateOptionCommand(
        List<CreateOptionDto> Options
        ) : ICommand<CreateOptionCommandResponse>;

    public sealed record CreateOptionDto(
       string QuestionId,
       string Description,
       bool IsAnswer);
}

using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.CreateOption;

public sealed record CreateOptionCommand(
    string QuestionId,
    List<CreateOptionDto> Options
    ) : ICommand<CreateOptionCommandResponse>;

public sealed record CreateOptionDto(
   string Description,
   bool IsAnswer
    );

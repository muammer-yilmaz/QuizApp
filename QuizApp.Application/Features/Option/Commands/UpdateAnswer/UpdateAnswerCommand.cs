using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.UpdateAnswer;

public sealed record UpdateAnswerCommand(
    string OldAnswerId,
    string NewAnswerId
    ) : ICommand<UpdateAnswerCommandResponse>;

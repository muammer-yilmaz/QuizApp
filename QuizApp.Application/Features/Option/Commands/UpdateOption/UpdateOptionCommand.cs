using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption;

public sealed record UpdateOptionCommand(
    string Id,
    string Description
    ) : ICommand<UpdateOptionCommandResponse>;

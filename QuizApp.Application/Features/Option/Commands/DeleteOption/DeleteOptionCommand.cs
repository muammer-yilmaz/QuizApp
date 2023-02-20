using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Option.Commands.DeleteOption;

public sealed record DeleteOptionCommand(
    string Id
    ) : ICommand<DeleteOptionCommandResponse>;

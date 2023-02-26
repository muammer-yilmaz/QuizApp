using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.QuizAttemp.Commands.CreateAttempt;

public sealed record CreateAttemptCommand(
    string QuizId
    ) : ICommand<CreateAttemptCommandResponse>;

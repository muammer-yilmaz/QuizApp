using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(
    string OldPassword,
    string NewPassword
    ) : ICommand<UpdatePasswordCommandResponse>;

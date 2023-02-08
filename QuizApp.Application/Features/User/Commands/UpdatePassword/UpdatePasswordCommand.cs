using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.UpdatePassword;

public sealed record UpdatePasswordCommand(
    string oldPassword,
    string newPassword
    ) : ICommand<UpdatePasswordCommandResponse>;

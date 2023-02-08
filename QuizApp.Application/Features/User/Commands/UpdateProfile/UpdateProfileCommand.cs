using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.UpdateProfile;

public sealed record UpdateProfileCommand(
    string Id,
    string FirstName,
    string LastName
    ) : ICommand<UpdateProfileCommandResponse>;

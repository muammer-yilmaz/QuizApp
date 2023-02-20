using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.UpdateProfile;

public sealed record UpdateProfileCommand : ICommand<UpdateProfileCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

using QuizApp.Application.Common.Consts;

namespace QuizApp.Application.Features.User.Commands.UpdateProfile;

public sealed record UpdateProfileCommandResponse()
{
    public string Message { get; set; } = Messages.UpdateSuccessful("User");
};
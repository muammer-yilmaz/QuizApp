using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : ICommandHandler<UpdateProfileCommand, UpdateProfileCommandResponse>
{
    private readonly IUserService _userService;
public UpdateProfileCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateProfileCommandResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateProfile(request);
        return new();
    }
}

using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Commands.UploadImage;

public class UploadImageCommandHandler : ICommandHandler<UploadImageCommand, UploadImageCommandResponse>
{
    private readonly IUserService _userService;

    public UploadImageCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UploadImageCommandResponse> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        await _userService.UploadProfilePicture(request);
        return new();
    }
}

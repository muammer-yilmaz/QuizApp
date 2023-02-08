using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.User.Commands.UpdatePassword;

public class UpdatePasswordCommandHandler : ICommandHandler<UpdatePasswordCommand, UpdatePasswordCommandResponse>
{
    private readonly IUserService _userService;

    public UpdatePasswordCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdatePassword(request);
        return new();
    }
}

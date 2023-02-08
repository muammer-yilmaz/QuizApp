using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Commands.ConfirmMail;

public class ConfirmMailCommandHandler : ICommandHandler<ConfirmMailCommand, ConfirmMailCommandResponse>
{
    private readonly IAuthService _authService;

    public ConfirmMailCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ConfirmMailCommandResponse> Handle(ConfirmMailCommand request, CancellationToken cancellationToken)
    {
        await _authService.ConfirmMail(request);
        return new();
    }
} 

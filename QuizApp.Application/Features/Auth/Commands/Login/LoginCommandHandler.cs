using MediatR;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;    
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request);

            return new LoginCommandResponse()
            {
                Token = result,
            };
        }
    }
}

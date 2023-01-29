using MediatR;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Auth.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateAsync(request);
            return new()
            {
                success = result 
            };
        }
    }
}

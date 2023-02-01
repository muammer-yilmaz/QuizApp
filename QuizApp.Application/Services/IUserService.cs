using QuizApp.Application.Features.Auth.Command.CreateUser;

namespace QuizApp.Application.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserCommand request);
    }
}

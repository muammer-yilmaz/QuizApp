using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;

namespace QuizApp.Application.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserCommand request);
        Task UpdateProfile(UpdateProfileCommand request);
        Task<GetUserQueryResponse> GetUserById(GetUserQuery request);
        Task<GetAllUsersQueryResponse> GetAllUsers(GetAllUsersQuery request);
    }
}

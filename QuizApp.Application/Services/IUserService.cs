using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Features.User.Commands.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdatePassword;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Commands.UploadImage;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;

namespace QuizApp.Application.Services;

public interface IUserService
{
    public Task CreateAsync(CreateUserCommand request);
    public Task UpdateProfile(UpdateProfileCommand request);
    public Task UpdatePassword(UpdatePasswordCommand request);
    public Task<GetUserQueryResponse> GetUserById(GetUserQuery request);
    public Task<GetAllUsersQueryResponse> GetAllUsers(GetAllUsersQuery request);
    public Task UploadProfilePicture(UploadImageCommand request);
    public Task UpdateScore(int score);
    public Task<List<LeaderboardDto>> GetLeaderboard();
}

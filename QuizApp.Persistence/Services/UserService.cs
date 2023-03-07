using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Abstraction.File;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.User.Commands.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdatePassword;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Commands.UploadImage;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using System.Net;
using System.Security.Claims;

namespace QuizApp.Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IHttpContextAccessor _httpContext;
    private readonly IImageService _imageService;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, IHttpContextAccessor httpContextAccessor, IImageService imageService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _httpContext = httpContextAccessor;
        _imageService = imageService;
    }

    public async Task CreateAsync(CreateUserCommand request)
    {
        await CheckIfAccountRegistered(request.Email, request.UserName);
        var user = _mapper.Map<AppUser>(request);
        user.Id = Guid.NewGuid().ToString();
        var imageUrl = await _imageService.UploadImage(Messages.GenerateRandomImage(user.Id), user.Id);
        user.ProfilePictureUrl = imageUrl;
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            await _imageService.DeleteImage(user.Id);
            throw new IdentityException(result.Errors.ToDictionary(p => p.Code, p => p.Description));
        }

        await SendConfirmationEmail(user);
    }

    public async Task<GetUserQueryResponse> GetUserById(GetUserQuery request)
    {
        string userId = GetIdFromContext();
        var result = await _userManager.FindByIdAsync(userId);
        if (result == null)
        {
            throw new NotFoundException(Messages.NotFound("User"));
        }
        var mapped = _mapper.Map<GetUserQueryResponse>(result);
        return mapped;
    }

    public async Task<GetAllUsersQueryResponse> GetAllUsers(GetAllUsersQuery request)
    {
        var result = await _userManager.Users.ToListAsync();

        return new GetAllUsersQueryResponse()
        {
            Users = result
        };
    }

    public async Task UpdateProfile(UpdateProfileCommand request)
    {
        var user = await CheckUserWithId(GetIdFromContext());

        user.FirstName = request.FirstName ?? user.FirstName;
        user.LastName = request.LastName ?? user.LastName;
        user.Biography = request.Biography ?? user.Biography;

        await _userManager.UpdateAsync(user);
    }

    public async Task UpdatePassword(UpdatePasswordCommand request)
    {
        var user = await CheckUserWithId(GetIdFromContext());
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

        if (result.Succeeded)
            return;

        var errors = result.Errors.ToDictionary(x => x.Code, x => x.Description);
        throw new IdentityException(errors);
    }

    public async Task UploadProfilePicture(UploadImageCommand request)
    {
        var userId = GetIdFromContext();
        var uploadResponse = await _imageService.UploadImage(request.image, userId);
        var user = await _userManager.FindByIdAsync(userId);
        user.ProfilePictureUrl = uploadResponse;
        await _userManager.UpdateAsync(user);
    }

    private async Task SendConfirmationEmail(AppUser user)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encoded = WebUtility.UrlEncode(token);
        EmailRequestDto request = new()
        {
            To = user.Email,
            Subject = "Confirm Email",
        };
        await _mailService.SendEmailConfirmationMail(request, encoded);
    }

    private async Task CheckIfAccountRegistered(string email, string userName)
    {
        var result = await _userManager.Users
            .Where(p => p.UserName == userName || p.Email == email)
            .FirstOrDefaultAsync();
        if (result != null)
            throw new BusinessException(Messages.DuplicateObject(
                (result.UserName == userName && result.Email == email)
                ? "Username and Email"
                : result.Email == email
                ? "Email"
                : "Username"
                ));
    }

    private string GetIdFromContext()
    {
        string? userId = _httpContext?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Authentication)?.Value;

        if (userId == null)
            throw new AuthorizationException(Messages.NoAuth);

        return userId;
    }

    private async Task<AppUser> CheckUserWithId(string id)
    {
        var result = await _userManager.FindByIdAsync(id);

        if (result == null)
            throw new NotFoundException("User");

        return result;
    }

    public async Task UpdateScore(int score)
    {
        var userId = GetIdFromContext();
        var user = await CheckUserWithId(userId);
        user.Score += score;
        await _userManager.UpdateAsync(user);
    }

}

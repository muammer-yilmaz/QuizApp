using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdatePassword;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using System.Net;
using System.Security.Claims;

namespace QuizApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _httpContext = httpContextAccessor;
        }

        public async Task CreateAsync(CreateUserCommand request)
        {
            await CheckIfEmailRegistered(request.EMail);
            await CheckIfUserNameRegistered(request.UserName);


            var user = _mapper.Map<AppUser>(request);
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await SendConfirmationEmail(user);
            }

        }

        public async Task<GetUserQueryResponse> GetUserById(GetUserQuery request)
        {
            var result = await _userManager.FindByIdAsync(request.Id);
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

        private async Task SendConfirmationEmail(AppUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encoded = WebUtility.UrlEncode(token);
            EmailRequest request = new()
            {
                To = user.Email,
                Subject = "Confirm Email",
            };
            await _mailService.SendEmailConfirmationMail(request, encoded);
        }

        private async Task CheckIfEmailRegistered(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result != null)
            {
                throw new BusinessException(Messages.DuplicateObject("Email"));
            }
        }

        private async Task CheckIfUserNameRegistered(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            if (result != null)
            {
                throw new BusinessException(Messages.DuplicateObject("Username"));
            }
        }
        private string GetIdFromContext()
        {
            string userId = _httpContext?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication).Value;
            if (userId == null)
            {
                throw new AuthorizationException(Messages.NoAuth);
            }
            return userId;
        }
        private async Task<AppUser> CheckUserWithId(string id)
        {
            var result = await _userManager.FindByIdAsync(id);
            if (result == null)
            {
                throw new NotFoundException("User");
            }
            return result;
        }

        public async Task UpdateProfile(UpdateProfileCommand request)
        {
            var user = await CheckUserWithId(GetIdFromContext());
            var mapped = _mapper.Map(request,user);
            await _userManager.UpdateAsync(mapped);
        }

        public async Task UpdatePassword(UpdatePasswordCommand request)
        {
            var user = await CheckUserWithId(GetIdFromContext());
            var result = await _userManager.ChangePasswordAsync(user, request.oldPassword, request.newPassword);
            if(result.Succeeded)
            {
                return;
            }
            var errors = result.Errors.ToDictionary(x => x.Code, x => x.Description);
            throw new IdentityException(errors);
        }
    }
}

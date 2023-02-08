using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task CreateAsync(CreateUserCommand request)
        {
            await CheckIfEmailRegistered(request.EMail);
            await CheckIfUserNameRegistered(request.UserName);


            var user = _mapper.Map<AppUser>(request);
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user, request.Password);
            //if (result.Succeeded)
            //{
            //await SendConfirmationEmail(user);
            //}

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
            EmailRequest request = new()
            {
                To = user.Email,
                Subject = "Confirm Email",
                Body = Messages.EmailMessage
            };
            await _mailService.SendEmailConfirmationMail(request, token);
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

        public async Task UpdateProfile(UpdateProfileCommand request)
        {
            var result = await _userManager.FindByIdAsync(request.Id);
            if(result == null)
            {
                throw new NotFoundException("User");
            }
            var mapped = _mapper.Map<AppUser>(request);
            await _userManager.UpdateAsync(mapped);
        }
    }
}

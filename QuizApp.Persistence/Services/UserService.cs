using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Command.CreateUser;
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
            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //await _mailService.SendEmailAsync(new Application.Common.DTOs.EmailMessage() 
              //  { Body = token, To = user.Email, Subject = "Confirm Email" });
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

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using System.Text;

namespace QuizApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateUserCommand request)
        {
            await CheckIfEmailRegistered(request.EMail);
            await CheckIfUserNameRegistered(request.UserName);

            var user = _mapper.Map<AppUser>(request);
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user,request.Password);
        }

        private async Task CheckIfEmailRegistered(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if(result != null)
            {
                throw new BusinessException(Messages.DuplicateObject("Email"));
            }
        }

        private async Task CheckIfUserNameRegistered(string userName)
        {
            var result = await _userManager.FindByNameAsync(userName);
            if( result != null )
            {
                throw new BusinessException(Messages.DuplicateObject("Username"));
            }
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuizApp.Application.Features.Auth.Command.CreateUser;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;

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
            var user = _mapper.Map<AppUser>(request);
            user.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user,request.Password);
        }
    }
}

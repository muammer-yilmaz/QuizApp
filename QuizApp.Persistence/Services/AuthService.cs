using Microsoft.AspNetCore.Identity;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.Consts;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using System.Net;

namespace QuizApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task ConfirmMail(ConfirmMailCommand request)
        {
            var user = await _userManager.FindByEmailAsync(request.Mail);
            if(user == null)
            {
                throw new NotFoundException(Messages.NotFound("Email"));
            }
            var result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if(result.Succeeded)
            {
                return;
            }
            var errors = result.Errors.ToDictionary(x => x.Code, x => x.Description);
            throw new IdentityException(errors);
        }

        public async Task<Token> LoginAsync(LoginCommand request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                throw new NotFoundException(Messages.NotFound("User"));
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateToken(user);
                return token;
            }
            //else if(result.IsNotAllowed && !user.EmailConfirmed)
            //{
            //    throw new AuthorizationException(Messages.EmailNotConfirmed);
            //}

            throw new AuthorizationException(Messages.PasswordMismatch);

        }
    }
}

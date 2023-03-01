using Microsoft.AspNetCore.Identity;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Features.Auth.Commands.ResetPassword;
using QuizApp.Application.Features.Auth.Queries.GetPasswordReset;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using System.Net;

namespace QuizApp.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenHandler;
    private readonly IMailService _mailService;

    public AuthService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenHandler,
        IMailService mailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _mailService = mailService;
    }

    public async Task<(TokenDto, string userId)> LoginAsync(LoginCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new NotFoundException(Messages.NotFound("User"));

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded)
        {
            var accessToken = _tokenHandler.CreateAccessToken(user, null);
            var refreshToken = _tokenHandler.CreateRefreshToken();

            var newToken = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Item1,
                RefreshTokenExpires = refreshToken.Item2
            };

            return (newToken, user.Id);
        }
        //else if(result.IsNotAllowed && !user.EmailConfirmed)
        //{
        //    throw new AuthorizationException(Messages.EmailNotConfirmed);
        //}

        throw new AuthorizationException(Messages.PasswordMismatch);
    }

    public async Task ConfirmMail(ConfirmMailCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new NotFoundException(Messages.NotFound("Email"));

        var token = DecodeToken(request.Token);
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return;

        var errors = result.Errors.ToDictionary(x => x.Code, x => x.Description);
        throw new IdentityException(errors);
    }

    public async Task GetPasswordReset(GetPasswordResetQuery request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new NotFoundException(Messages.NotFound("User"));

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encoded = WebUtility.UrlEncode(token);

        EmailRequestDto email = new()
        {
            To = request.Email,
            Subject = "Password Reset",
        };

        await _mailService.SendPasswordResetEmail(email, encoded);
    }

    public async Task PasswordResetConfirm(ResetPasswordCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new NotFoundException(Messages.NotFound("User"));

        var token = DecodeToken(request.Token);
        var identityResult = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

        if (identityResult.Succeeded)
            return;

        var errors = identityResult.Errors.ToDictionary(x => x.Code, x => x.Description);
        throw new IdentityException(errors);
    }

    private string DecodeToken(string token)
    {
        var charArray = new[] { '+', '#', '*', '<', '>', '|', '#', '(', ')' };
        var decodedToken = token.IndexOfAny(charArray) >= 0 ? token : WebUtility.UrlDecode(token);
        return decodedToken;
    }

}

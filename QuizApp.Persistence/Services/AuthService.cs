using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Features.Auth.Commands.ConfirmMail;
using QuizApp.Application.Features.Auth.Commands.Login;
using QuizApp.Application.Features.Auth.Commands.RefreshToken;
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
    private readonly ITokenHandler _tokenHandler;
    private readonly IMailService _mailService;

    public AuthService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenHandler tokenHandler,
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

    public async Task<TokenDto> RefreshToken(RefreshTokenCommand request)
    {
        //var user = await _userManager.Users.FirstOrDefaultAsync(p => p.RefreshToken == request.Token.RefreshToken);

        //if (user == null)
        //    throw new BusinessException(Messages.NotFound("User with associated Refresh Token"));

        //if (user.RefreshTokenExpires <= DateTime.UtcNow)
        //    throw new BusinessException(Messages.RefreshTokenExpires);

        ////later for claims and if necessary with ownership control

        ////var userIdFromOldToken = _tokenHandler.ValidateJwtToken(request.Token.AccessToken);

        //var token = _tokenHandler.CreateAccessToken(user);

        //user.RefreshToken = token.RefreshToken;
        //user.RefreshTokenExpires = token.RefreshTokenExpires;

        //await _userManager.UpdateAsync(user);

        //return token;
        throw new NotImplementedException();
    }

    private string DecodeToken(string token)
    {
        var charArray = new[] { '+', '#', '*', '<', '>', '|', '#', '(', ')' };
        var decodedToken = token.IndexOfAny(charArray) >= 0 ? token : WebUtility.UrlDecode(token);
        return decodedToken;
    }

}

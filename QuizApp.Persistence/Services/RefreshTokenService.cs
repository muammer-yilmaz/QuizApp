using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.Constants;
using QuizApp.Application.Common.DTOs;
using QuizApp.Application.Common.Exceptions;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;

namespace QuizApp.Persistence.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;
    private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
    private IHttpContextAccessor _contextAccessor;
    private ITokenService _tokenHandler;

    public RefreshTokenService(IRefreshTokenReadRepository refreshTokenReadRepository, IRefreshTokenWriteRepository refreshTokenWriteRepository, IHttpContextAccessor contextAccessor, ITokenService tokenHandler)
    {
        _refreshTokenReadRepository = refreshTokenReadRepository;
        _refreshTokenWriteRepository = refreshTokenWriteRepository;
        _contextAccessor = contextAccessor;
        _tokenHandler = tokenHandler;
    }

    public async Task CreateRefreshToken(string userId, string token, DateTime expires)
    {
        var newToken = new RefreshToken
        {
            Token = token,
            UserId = userId,
            TokenExpires = expires,
            CreatedByIp = GetIpFromContext()
        };

        await _refreshTokenWriteRepository.AddAsync(newToken);
        await _refreshTokenWriteRepository.SaveAsync();

    }

    public async Task<TokenDto> GetRefreshToken(TokenDto tokenDto)
    {
        var token = await _refreshTokenReadRepository.GetAll(false)
            .Where(p => p.Token == tokenDto.RefreshToken)
            .FirstOrDefaultAsync();
        if (token == null)
            throw new BusinessException("GetRefreshToken token == null");

        var newRefreshToken = _tokenHandler.CreateRefreshToken();
        var oldClaims = _tokenHandler.GetClaimsFromExpiredToken(tokenDto.AccessToken);
        var newAccessToken = _tokenHandler.CreateAccessToken(null, oldClaims);

        return new TokenDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Item1,
            RefreshTokenExpires = newRefreshToken.Item2
        };
    }

    public async Task UpdateRefreshToken(string oldRefreshToken,TokenDto tokenDto)
    {
        var token = await _refreshTokenReadRepository.GetAll()
            .Where(p => p.Token == oldRefreshToken)
            .FirstOrDefaultAsync();

        if (token == null)
            throw new BusinessException(Messages.NotFound("Refresh Token"));

        token.Token = tokenDto.RefreshToken;
        token.TokenExpires = tokenDto.RefreshTokenExpires;
        token.RevokedByIp = GetIpFromContext();
        token.PreviousToken = oldRefreshToken;

        _refreshTokenWriteRepository.Update(token);
        await _refreshTokenWriteRepository.SaveAsync();
    }

    private string GetIpFromContext() {
        var ip = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        return ip;
    }
}

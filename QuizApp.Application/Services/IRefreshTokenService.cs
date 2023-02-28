using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Services;

public interface IRefreshTokenService
{
    public Task CreateRefreshToken(string userId, string token, DateTime expires);
    public Task UpdateRefreshToken(string oldRefreshToken,TokenDto tokenDto);
    public Task<TokenDto> GetRefreshToken(TokenDto tokenDto);
}

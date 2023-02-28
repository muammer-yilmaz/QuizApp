using QuizApp.Application.Common.DTOs;
using QuizApp.Domain.Entities.Identity;
using System.Security.Claims;

namespace QuizApp.Application.Abstraction.Token;

public interface ITokenHandler
{
    string CreateAccessToken(AppUser? appUser, IEnumerable<Claim>? oldClaims);
    (string, DateTime) CreateRefreshToken();
    public IEnumerable<Claim> GetClaimsFromExpiredToken(string token);


}

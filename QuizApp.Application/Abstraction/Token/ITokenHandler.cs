using QuizApp.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace QuizApp.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        Common.DTOs.Token CreateToken(AppUser appUser);
        JwtSecurityToken ValidateJwtToken(string token);
    }
}

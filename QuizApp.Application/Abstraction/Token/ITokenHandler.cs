using QuizApp.Application.Common.DTOs;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Application.Abstraction.Token;

public interface ITokenHandler
{
    TokenDto CreateToken(AppUser appUser);
    //JwtSecurityToken ValidateJwtToken(string token);
}

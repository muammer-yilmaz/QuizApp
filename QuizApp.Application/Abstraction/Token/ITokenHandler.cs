using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        Common.DTOs.Token CreateToken(AppUser appUser);
    }
}

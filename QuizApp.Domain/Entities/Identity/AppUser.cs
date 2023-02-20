using Microsoft.AspNetCore.Identity;

namespace QuizApp.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpires { get; set; }
    public int Score { get; set; }
    public string? Biography { get; set; }

}

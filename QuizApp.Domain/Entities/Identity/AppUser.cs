using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace QuizApp.Domain.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Score { get; set; } = 0;
    public string? Biography { get; set; }
    public string ProfilePictureUrl { get; set; }

}

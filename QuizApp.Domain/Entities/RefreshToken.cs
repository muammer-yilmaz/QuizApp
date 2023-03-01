using QuizApp.Domain.Common;
using QuizApp.Domain.Entities.Identity;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string UserId { get; set; }
    [JsonIgnore]
    public AppUser User { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpires { get; set; }
    public string CreatedByIp { get; set; }
    public string? RevokedByIp { get; set; }
    public string? PreviousToken { get; set; }
    public bool IsExpired => TokenExpires <= DateTime.UtcNow;
}

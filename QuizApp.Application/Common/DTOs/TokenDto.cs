using System.Text.Json.Serialization;

namespace QuizApp.Application.Common.DTOs;

public class TokenDto
{
    public string AccessToken { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }
    [JsonIgnore]
    public DateTime RefreshTokenExpires { get; set; }
}

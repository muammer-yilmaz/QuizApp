namespace QuizApp.Application.Common.DTOs;

public class LeaderboardDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserPhotoUrl { get; set; }
    public int Score { get; set; }
}

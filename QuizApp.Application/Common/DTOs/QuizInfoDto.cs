namespace QuizApp.Application.Common.DTOs;

public class QuizInfoDto
{
    public string QuizId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string UserName { get; set; }
    public string UserPhotoUrl { get; set; }
    public DateTime QuizCreatedDate { get; set; }

}

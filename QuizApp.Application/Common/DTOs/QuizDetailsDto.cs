namespace QuizApp.Application.Common.DTOs;

public class QuizDetailsDto 
{
    public string QuizId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public ICollection<QuizDetailQuestionsDto> Questions { get; set; }

}

public class QuizDetailQuestionsDto
{
    public string QuestionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<QuizDetailOptionsDto> Options { get; set; }
}

public class QuizDetailOptionsDto
{
    public string OptionId { get; set; }
    public string Description { get; set; }
}

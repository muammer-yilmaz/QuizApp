namespace QuizApp.Application.Common.DTOs;

public class QuizFinishDto
{
    public string QuizId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<QuizFinishQuestionsDto> Questions { get; set; }
}

// Boş gönderilen soruların kontrolü ve diğer güvenli kontorlü yap.
public class QuizFinishQuestionsDto
{
    public string QuestionId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SelectedOptionId { get; set; }
    public string SelectedOptionDescription { get; set; }
}

public class QuizFinishResultDto
{
    public string QuizId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CorrectAnswerCount { get; set; }
    public int Score { get; set; }
    public List<QuizFinishResultQuestionsDto> Questions { get; set; }
}

public class QuizFinishResultQuestionsDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string SelectedOptionDescription { get; set; }
    public bool IsCorrect { get; set; }
}

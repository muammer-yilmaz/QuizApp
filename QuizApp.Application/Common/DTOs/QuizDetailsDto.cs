using QuizApp.Domain.Common;

namespace QuizApp.Application.Common.DTOs;

public class QuizDetailsDto : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public ICollection<QuestionsDto> Questions { get; set; }

}

public class QuestionsDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<OptionsDto> Options { get; set; }
}

public class OptionsDto
{
    public string Description { get; set; }
    public bool IsAnswer { get; set; }
}

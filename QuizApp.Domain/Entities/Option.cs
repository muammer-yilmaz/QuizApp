using QuizApp.Domain.Common;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities;

public class Option : BaseEntity
{
    public string QuestionId { get; set; }
    [JsonIgnore]
    public Question Question { get; set; }
    public string Description { get; set; }
    public bool IsAnswer { get; set; }
}

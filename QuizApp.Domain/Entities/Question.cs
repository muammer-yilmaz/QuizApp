using QuizApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities;

public class Question : BaseEntity
{
    [ForeignKey("Quiz")]
    public string QuizId { get; set; }
    [JsonIgnore]
    public Quiz Quiz { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Option> Options { get; set; }

}

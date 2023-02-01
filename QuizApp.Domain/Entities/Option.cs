using QuizApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities
{
    public class Option : BaseEntity
    {
        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
        public string Description { get; set; }
        public bool IsAnswer { get; set; }
    }
}

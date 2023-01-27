using QuizApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entities
{
    public class Option : BaseEntity
    {
        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public string Description { get; set; }
        public bool IsAnswer { get; set; }
    }
}

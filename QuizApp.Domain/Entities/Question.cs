using QuizApp.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        [ForeignKey("Quiz")]
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

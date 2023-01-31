using QuizApp.Domain.Common;
using QuizApp.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public string Description { get; set; }

    }
}

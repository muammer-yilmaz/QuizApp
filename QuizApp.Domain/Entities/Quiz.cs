using QuizApp.Domain.Common;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

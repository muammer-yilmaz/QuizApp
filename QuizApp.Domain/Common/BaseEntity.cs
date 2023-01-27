namespace QuizApp.Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

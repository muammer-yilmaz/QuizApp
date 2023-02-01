using System.Text.Json.Serialization;

namespace QuizApp.Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? UpdatedDate { get; set; }
    }

}

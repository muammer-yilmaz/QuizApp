using QuizApp.Domain.Common;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Domain.Entities;

public  class QuizAttempt : BaseEntity
{
    public string QuizId { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public bool IsFinished { get; set; }
    public string? QuizResultJson { get; set; }

}

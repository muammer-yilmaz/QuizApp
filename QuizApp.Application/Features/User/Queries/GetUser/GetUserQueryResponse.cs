namespace QuizApp.Application.Features.User.Queries.GetUser;

public sealed record GetUserQueryResponse()
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Score { get; set; }
    public string Biography { get; set; }
}

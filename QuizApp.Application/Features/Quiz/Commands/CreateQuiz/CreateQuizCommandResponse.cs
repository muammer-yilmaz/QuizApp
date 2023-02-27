using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

public sealed record CreateQuizCommandResponse
{
    public string Message { get; } = Messages.CreateSuccessful("Quiz");
    public string QuizId { get; set; }
}


// TODO : Result struct for later
/*

public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class ErrorResult : Result
{
    public ErrorResult()
    {
        IsSuccess = false;
    }
}
*/
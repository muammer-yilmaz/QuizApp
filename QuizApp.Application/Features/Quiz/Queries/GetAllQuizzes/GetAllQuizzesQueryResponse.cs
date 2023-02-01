namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes
{
    public sealed record GetAllQuizzesQueryResponse(
            List<Domain.Entities.Quiz> Quizzes
    );
}

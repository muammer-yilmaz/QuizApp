using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Queries.GetAllQuizzes
{
    public class GetAllQuizzesQueryHandler : IQueryHandler<GetAllQuizzesQuery, GetAllQuizzesQueryResponse>
    {
        private readonly IQuizService _quizService;

        public GetAllQuizzesQueryHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task<GetAllQuizzesQueryResponse> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            var result = await _quizService.GetAllQuizzesAsync();
            return new(result);
        }
    }
}

using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : ICommandHandler<UpdateQuizCommand, UpdateQuizCommandResponse>
    {
        private readonly IQuizService _quizService;

        public UpdateQuizCommandHandler(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public async Task<UpdateQuizCommandResponse> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            await _quizService.UpdateQuizAsync(request);
            return new();
        }
    }
}

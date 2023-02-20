using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Commands.DeleteQuiz;

public class DeleteQuizCommandHandler : ICommandHandler<DeleteQuizCommand, DeleteQuizCommandResponse>
{
    private readonly IQuizService _quizService;

    public DeleteQuizCommandHandler(IQuizService quizService)
    {
        _quizService = quizService;
    }

    public async Task<DeleteQuizCommandResponse> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        await _quizService.DeleteQuizAsync(request.Id);
        return new();
    }
}

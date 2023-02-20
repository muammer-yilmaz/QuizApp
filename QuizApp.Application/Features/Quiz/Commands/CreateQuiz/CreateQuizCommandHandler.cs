using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Services;

namespace QuizApp.Application.Features.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandHandler : ICommandHandler<CreateQuizCommand, CreateQuizCommandResponse>
{
    private readonly IQuizService _quizService;

    public CreateQuizCommandHandler(IQuizService quizService)
    {
        _quizService = quizService;
    }

    public async Task<CreateQuizCommandResponse> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        await _quizService.CreateQuizAsync(request);
        return new();
    }
}

using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Commands.StartQuiz;

public sealed record StartQuizCommand(
    string QuizId
    ) : ICommand<StartQuizCommandResponse>;

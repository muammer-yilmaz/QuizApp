using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Quiz.Commands.UpdateQuiz;

public sealed record UpdateQuizCommand(
    string Id,
    string Title,
    string Description
) : ICommand<UpdateQuizCommandResponse>;

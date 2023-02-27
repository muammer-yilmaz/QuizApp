using QuizApp.Application.Abstraction.Messaging;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Application.Features.Quiz.Commands.FinishQuiz;

public sealed record FinishQuizCommand(
    QuizFinishDto Quiz
    ) : ICommand<FinishQuizCommandResponse>;

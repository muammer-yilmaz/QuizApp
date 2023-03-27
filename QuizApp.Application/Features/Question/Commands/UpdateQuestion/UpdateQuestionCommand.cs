using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion;

public sealed record UpdateQuestionCommand(
    string Id,
    string Title,
    string Description
    ) : ICommand<UpdateQuestionCommandResponse>;

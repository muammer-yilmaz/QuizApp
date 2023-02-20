using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Category.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(
    string Id
    ) : ICommand<DeleteCategoryCommandResponse>;

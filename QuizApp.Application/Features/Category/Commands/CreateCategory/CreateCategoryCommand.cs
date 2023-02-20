using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    string CategoryName
    ) : ICommand<CreateCategoryCommandResponse>;

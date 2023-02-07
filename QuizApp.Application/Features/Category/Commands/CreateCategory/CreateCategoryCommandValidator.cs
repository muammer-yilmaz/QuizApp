using FluentValidation;

namespace QuizApp.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
	public CreateCategoryCommandValidator()
	{
		RuleFor(p => p.CategoryName).NotEmpty().MinimumLength(2).MaximumLength(50);
	}
}

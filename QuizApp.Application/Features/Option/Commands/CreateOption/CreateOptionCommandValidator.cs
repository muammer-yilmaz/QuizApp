using FluentValidation;

namespace QuizApp.Application.Features.Option.Commands.CreateOption;

public class CreateOptionCommandValidator : AbstractValidator<CreateOptionCommand>
{
	public CreateOptionCommandValidator()
	{
		RuleFor(p => p.Description).NotEmpty();
		RuleFor(p => p.QuestionId).NotEmpty();
	}
}

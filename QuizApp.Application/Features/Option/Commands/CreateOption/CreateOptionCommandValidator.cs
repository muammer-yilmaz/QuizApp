using FluentValidation;

namespace QuizApp.Application.Features.Option.Commands.CreateOption;

public class CreateOptionCommandValidator : AbstractValidator<CreateOptionCommand>
{
	public CreateOptionCommandValidator()
	{
		RuleFor(p => p.Options).NotEmpty();
		RuleFor(p => p.Options.Count).InclusiveBetween(2, 4);
		RuleForEach(p => p.Options).ChildRules(child =>
		{
			child.RuleFor(p => p.Description).NotEmpty();
			child.RuleFor(p => p.QuestionId).NotEmpty();
		});
	}
}

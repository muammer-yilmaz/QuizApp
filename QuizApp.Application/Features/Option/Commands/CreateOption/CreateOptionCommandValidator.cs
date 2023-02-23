using FluentValidation;
using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.Option.Commands.CreateOption;

public class CreateOptionCommandValidator : AbstractValidator<CreateOptionCommand>
{
	public CreateOptionCommandValidator()
	{
		RuleFor(p => p.Options).NotEmpty();
        RuleFor(p => p.QuestionId).NotEmpty();
        RuleFor(p => p.Options.Count).InclusiveBetween(2, 4).OverridePropertyName("Options");
		RuleForEach(p => p.Options).ChildRules(child =>
		{
			child.RuleFor(p => p.Description).NotEmpty();
		});
	}
}

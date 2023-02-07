using FluentValidation;

namespace QuizApp.Application.Features.Option.Commands.UpdateOption;

public class UpdateOptionCommandValidator : AbstractValidator<UpdateOptionCommand>
{
	public UpdateOptionCommandValidator()
	{
		RuleFor(p => p.Description).NotEmpty();
		RuleFor(p => p.Id).NotEmpty();
	}
}

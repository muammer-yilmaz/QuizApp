using FluentValidation;

namespace QuizApp.Application.Features.Auth.Commands.ConfirmMail;

public class ConfirmMailCommandValidator : AbstractValidator<ConfirmMailCommand>
{
	public ConfirmMailCommandValidator()
	{
		RuleFor(p => p.Email).NotEmpty().EmailAddress();
		RuleFor(p => p.Token).NotEmpty();
	}
}

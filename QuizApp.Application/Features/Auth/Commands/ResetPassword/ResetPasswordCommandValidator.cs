using FluentValidation;

namespace QuizApp.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
	public ResetPasswordCommandValidator()
	{
		RuleFor(p => p.Email).NotEmpty().EmailAddress();
		RuleFor(p => p.Token).NotEmpty();
		RuleFor(p => p.NewPassword).NotEmpty().MinimumLength(6).MaximumLength(50);
	}
}

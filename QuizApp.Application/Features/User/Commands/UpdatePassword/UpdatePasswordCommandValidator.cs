using FluentValidation;

namespace QuizApp.Application.Features.User.Commands.UpdatePassword;

public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
	public UpdatePasswordCommandValidator()
	{
		RuleFor(p => p.OldPassword).NotEmpty();
		RuleFor(p => p.NewPassword).NotEmpty().MaximumLength(6).MaximumLength(50);
	}
}

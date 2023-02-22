using FluentValidation;
using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.User.Commands.UploadImage;

public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
	public UploadImageCommandValidator()
	{
		RuleFor(p => p.image.Length).LessThanOrEqualTo(2500000)
			.WithMessage(Messages.MaximumFileSizeExceeded);

		RuleFor(p => p.image.ContentType).NotNull()
			.Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
			.WithMessage(Messages.UnsupportedExtension);
			

    }
}

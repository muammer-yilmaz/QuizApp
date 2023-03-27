using FluentValidation;

namespace QuizApp.Application.Features.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
	public UpdateQuestionCommandValidator()
	{
		RuleFor(p => p.Title).NotEmpty();
		RuleFor(p => p.Description).NotEmpty();
		RuleFor(p => p.Id).NotEmpty();
	}
}

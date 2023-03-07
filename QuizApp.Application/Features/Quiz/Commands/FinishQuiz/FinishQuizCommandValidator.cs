using FluentValidation;

namespace QuizApp.Application.Features.Quiz.Commands.FinishQuiz;

public class FinishQuizCommandValidator : AbstractValidator<FinishQuizCommand>
{
	public FinishQuizCommandValidator()
	{
		RuleFor(p => p.Quiz).NotEmpty();
		RuleFor(p => p.Quiz.QuizId).NotEmpty();
		RuleFor(p => p.Quiz.Title).NotEmpty();
		RuleFor(p => p.Quiz.Description).NotEmpty();
		RuleFor(p => p.Quiz.Questions).NotEmpty();
		RuleForEach(p => p.Quiz.Questions).ChildRules(child =>
		{
			child.RuleFor(p => p.QuestionId).NotEmpty();
			child.RuleFor(p => p.Title).NotEmpty();
			child.RuleFor(p => p.Description).NotEmpty();
		});
	}
}

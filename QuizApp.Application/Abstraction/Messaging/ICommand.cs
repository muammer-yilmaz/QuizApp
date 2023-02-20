using MediatR;

namespace QuizApp.Application.Abstraction.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

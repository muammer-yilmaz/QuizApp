using MediatR;

namespace QuizApp.Application.Abstraction.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

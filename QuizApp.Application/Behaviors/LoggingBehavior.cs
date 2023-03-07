using MediatR;
using Serilog;

namespace QuizApp.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.Information(
            "Starting request {@RequestName} , {@DateTimeUtc}"
            , typeof(TRequest).Name,
            DateTime.UtcNow
            );

        var result = await next();

        _logger.Information(
           "Completed request {@RequestName} , {@DateTimeUtc} , {@Result}"
           ,typeof(TRequest).Name,
           DateTime.UtcNow,
           result
           );

        return result;
    }
}

using QuizApp.Application.Common.Exceptions;
using Serilog;
using System.Text.Json;

namespace QuizApp.WebAPI.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly Serilog.ILogger _logger;

    public ExceptionMiddleware(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        object? errors = GetValidationErrors(exception);

        _logger.Error(
            "Error of {@ErrorType}, with message {@ErrorMessage}, inner message {@ErrorInnerMessage} , {@DateTimeUtc}"
            ,exception.GetType().Name,
            exception.Message,
            exception.InnerException?.Message,
            DateTime.UtcNow
            );

        var error = exception.Message;

        var response = new
        {
            status = statusCode,
            errors = errors,
            inner = exception?.InnerException?.Message,
            error = error,
        };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response,new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        }));
    }
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BusinessException or IdentityException => StatusCodes.Status400BadRequest,
            AuthorizationException => StatusCodes.Status401Unauthorized,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError
        };

    private static object? GetValidationErrors(Exception exception)
    {
        if (exception is ValidationException validationException)
        {
            return validationException.ErrorsDictionary;
        }
        else if (exception is IdentityException identityException)
        {
            return identityException.Errors;
        }
        return null;
    }
}

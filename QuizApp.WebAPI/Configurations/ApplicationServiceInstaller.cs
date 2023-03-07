using FluentValidation;
using MediatR;
using QuizApp.Application.Behaviors;

namespace QuizApp.WebAPI.Configurations;

public static class ApplicationServiceInstaller
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
    }
}

using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.DTOs;
using QuizApp.Infrastructure.Authentication;
using QuizApp.Infrastructure.Mailing;

namespace QuizApp.WebAPI.Configurations;

public static class InfrastructureServiceInstaller
{
    public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ITokenHandler, TokenHandler>();
        services.AddScoped<IMailService, MailService>();

        var emailConfig = configuration.GetSection("Email").Get<EmailConfigurationDto>();
        services.AddSingleton(emailConfig);
    }
}

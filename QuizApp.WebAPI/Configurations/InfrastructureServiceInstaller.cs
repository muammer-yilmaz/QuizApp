﻿using QuizApp.Application.Abstraction.Email;
using QuizApp.Application.Abstraction.File;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Common.DTOs;
using QuizApp.Infrastructure.Authentication;
using QuizApp.Infrastructure.File.Image;
using QuizApp.Infrastructure.Mailing;

namespace QuizApp.WebAPI.Configurations;

public static class InfrastructureServiceInstaller
{
    public static void AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IImageService, CloudinaryImageService>();
        services.AddScoped<IMailService, MailService>();

        var emailConfig = configuration.GetSection("Email").Get<EmailConfigurationDto>();
        services.AddSingleton(emailConfig);

        var cloudinaryConfig = configuration.GetSection("Cloudinary").Get<CloudinaryConfigurationDto>();
        services.AddSingleton(cloudinaryConfig);

    }
}

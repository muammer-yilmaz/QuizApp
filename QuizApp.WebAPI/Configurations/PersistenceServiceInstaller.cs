using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities.Identity;
using QuizApp.Persistence;
using QuizApp.Persistence.Repositories;
using QuizApp.Persistence.Services;

namespace QuizApp.WebAPI.Configurations;

public static class PersistenceServiceInstaller
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
            //options.SignIn.RequireConfirmedEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        services.AddHttpContextAccessor();

        services.AddScoped<IQuizWriteRepository, QuizWriteRepository>();
        services.AddScoped<IQuizReadRepository, QuizReadRepository>();

        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

        services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
        services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();

        services.AddScoped<IOptionWriteRepository, OptionWriteRepository>();
        services.AddScoped<IOptionReadRepository, OptionReadRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IQuizService, QuizService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IOptionService, OptionService>();
    }
}

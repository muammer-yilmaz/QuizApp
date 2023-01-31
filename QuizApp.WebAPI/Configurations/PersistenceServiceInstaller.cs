﻿using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Repositories;
using QuizApp.Application.Services;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;
using QuizApp.Persistence;
using QuizApp.Persistence.Repositories;
using QuizApp.Persistence.Services;

namespace QuizApp.WebAPI.Configurations
{
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
            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IQuizWriteRepository, QuizWriteRepository>();
            services.AddScoped<IQuizReadRepository, QuizReadRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IQuizService, QuizService>();
        }
    }
}
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Application.Behaviors;
using QuizApp.WebAPI.Configurations;
using QuizApp.WebAPI.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAplicationServices();
builder.Services.AddApiServices(builder.Configuration);

builder.Services.AddScoped<ITokenHandler,QuizApp.Infrastructure.Authentication.TokenHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

//app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

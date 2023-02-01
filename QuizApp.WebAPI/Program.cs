using QuizApp.Application.Abstraction.Token;
using QuizApp.WebAPI.Configurations;
using QuizApp.WebAPI.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAplicationServices();
builder.Services.AddApiServices(builder.Configuration);

builder.Services.AddScoped<ITokenHandler, QuizApp.Infrastructure.Authentication.TokenHandler>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

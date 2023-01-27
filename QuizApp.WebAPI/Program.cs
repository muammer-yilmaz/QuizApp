using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application;
using QuizApp.Domain.Entities;
using QuizApp.Persistence;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddIdentity<User,Role>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMediatR(typeof(QuizApp.Application.AssemblyReference).Assembly);
builder.Services.AddAutoMapper(typeof(QuizApp.Persistence.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

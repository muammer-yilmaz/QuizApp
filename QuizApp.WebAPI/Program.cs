using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using QuizApp.WebAPI.Configurations;
using QuizApp.WebAPI.Middlewares;
using Serilog;
using Serilog.Events;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
    configuration.WriteTo.MongoDBBson(conf =>
    {
        conf.SetMongoUrl(context.Configuration["MongoUrl"]!);
        conf.SetCollectionName("log");
    }, LogEventLevel.Error);
});

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAplicationServices();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddLogging();

builder.Services.AddDataProtection().UseCryptographicAlgorithms(
    new AuthenticatedEncryptorConfiguration
    {
        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
    });


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//.AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonTrimConverter()));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(p =>
{
    p.InjectStylesheet("/swagger-ui/SwaggerDark.css");
});

app.MapGet("/swagger-ui/SwaggerDark.css", async (CancellationToken cancellationToken) =>
{
    var css = await File.ReadAllBytesAsync("SwaggerDark.css", cancellationToken);
    return Results.File(css, "text/css");
}).ExcludeFromDescription();

app.UseCors();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

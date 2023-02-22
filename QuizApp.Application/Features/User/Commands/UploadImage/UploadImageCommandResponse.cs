using QuizApp.Application.Common.Constants;

namespace QuizApp.Application.Features.User.Commands.UploadImage;

public sealed record UploadImageCommandResponse
{
    public string Message { get; set; } = Messages.ImageUploadSuccessful;
}
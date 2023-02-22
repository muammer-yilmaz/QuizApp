using Microsoft.AspNetCore.Http;
using QuizApp.Application.Abstraction.Messaging;

namespace QuizApp.Application.Features.User.Commands.UploadImage;

public sealed record UploadImageCommand(
    IFormFile image
    ) : ICommand<UploadImageCommandResponse>;

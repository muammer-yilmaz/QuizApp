using Microsoft.AspNetCore.Http;

namespace QuizApp.Application.Abstraction.File;

public interface IImageService
{
    public Task<string> UploadImage(IFormFile image,string publicId);
    public Task<string> UploadImage(string imageUrl,string publicId);
    public Task<bool> DeleteImage(string id);
}

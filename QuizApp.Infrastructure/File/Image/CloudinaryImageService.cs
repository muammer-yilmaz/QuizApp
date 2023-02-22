using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using QuizApp.Application.Abstraction.File;
using QuizApp.Application.Common.DTOs;

namespace QuizApp.Infrastructure.File.Image;

public class CloudinaryImageService : IImageService
{
    private readonly CloudinaryConfigurationDto _cloudinaryConfigurationDto;
    private readonly Cloudinary _cloudinary;

    public CloudinaryImageService(CloudinaryConfigurationDto cloudinaryConfigurationDto)
    {
        _cloudinaryConfigurationDto = cloudinaryConfigurationDto;
        _cloudinary = new Cloudinary(new Account()
        {
            Cloud = _cloudinaryConfigurationDto.CloudName,
            ApiKey = _cloudinaryConfigurationDto.ApiKey,
            ApiSecret = _cloudinaryConfigurationDto.ApiSecret
        });
    }
    public async Task<string> UploadImage(IFormFile image, string publicId)
    {
        var parameters = new ImageUploadParams()
        {
            File = new(image.FileName, image.OpenReadStream()),
            PublicId = $"profiles/{publicId}",
            Overwrite = true,
            UseFilename = false,
        };
        var result = await _cloudinary.UploadAsync(parameters);
        return result.SecureUrl.ToString();
    }

    public async Task<string> UploadImage(string imageUrl, string publicId)
    {
        var parameters = new ImageUploadParams()
        {
            File = new FileDescription(imageUrl),
            PublicId = $"profiles/{publicId}",
            Overwrite = true,
            UseFilename = false,
            Format = "png" 
        };
        var result = await _cloudinary.UploadAsync(parameters);
        return result.SecureUrl.ToString();
    }



    public Task DeleteImage(string id)
    {
        throw new NotImplementedException();
    }


}

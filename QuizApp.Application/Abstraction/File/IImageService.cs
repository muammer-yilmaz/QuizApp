﻿using Microsoft.AspNetCore.Http;

namespace QuizApp.Application.Abstraction.File;

public interface IImageService
{
    public Task<string> UploadImage(IFormFile image,string publicId);
    public Task DeleteImage(string id);
}
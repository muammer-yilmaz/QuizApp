﻿using QuizApp.Application.Abstraction.Token;
using QuizApp.Persistence.Services;

namespace QuizApp.WebAPI.Middlewares;

public class AuthenticationMiddleware : IMiddleware
{
    private ITokenService _tokenHandler;

    public AuthenticationMiddleware(ITokenService tokenHandler)
    {
        _tokenHandler = tokenHandler;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var jwt = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (jwt == null)
            throw new Exception("Doğrulama başarısız");

        //var token = _tokenHandler.ValidateJwtToken(jwt);

        //context.Items["User"] = token;

        await next(context);
    }
}

using QuizApp.Application.Abstraction.Token;
using QuizApp.Persistence.Services;

namespace QuizApp.WebAPI.Middlewares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        private ITokenHandler _tokenHandler;

        public AuthenticationMiddleware(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var jwt = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (jwt == null)
                throw new Exception("Doğrulama başarısız");

            var token = await _tokenHandler.ValidateJwtToken(jwt);

            context.Items["User"] = token;

            await next(context);
        }
    }
}

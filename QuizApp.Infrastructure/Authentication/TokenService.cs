using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Application.Abstraction.Token;
using QuizApp.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Infrastructure.Authentication;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // TODO : Split this method to parts later
    public string CreateAccessToken(AppUser? appUser, IEnumerable<Claim>? oldClaims)
    {
        //Security Key'in simetriğini alıyoruz.
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        //Şifrelenmiş kimliği oluşturuyoruz.
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName,appUser?.UserName ?? ""),
            new Claim(JwtRegisteredClaimNames.Email, appUser?.Email ?? ""),
            new Claim(ClaimTypes.Authentication, appUser?.Id ?? ""),
            //new Claim(ClaimTypes.Role, String.Join(",", roles))
        };


        //Oluşturulacak token ayarlarını veriyoruz.
        var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Token:AccessTokenExpirationInMinutes"]));

        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims : oldClaims ?? claims
            );

        //Token oluşturucu sınıfından bir örnek alalım.
        JwtSecurityTokenHandler tokenHandler = new();
        var token = tokenHandler.WriteToken(securityToken);


        return token;
    }

    public (string,DateTime) CreateRefreshToken()
    {
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Token:RefreshTokenExpirationInDays"]));

        return (refreshToken, refreshTokenExpires);
    }

    public IEnumerable<Claim>  GetClaimsFromExpiredToken(string token)
    {
        var claimsPrincipal = ValidateToken(token);
        return claimsPrincipal.Claims;
    }

    private string GenerateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
    
    private ClaimsPrincipal ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var secretKey = Encoding.ASCII.GetBytes(_configuration["Token:SecurityKey"]);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
        };

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}

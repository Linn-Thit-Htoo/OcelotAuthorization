using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OcelotAuthorization.Auth.Services;

public class JWTAuth
{
    private readonly IConfiguration _configuration;

    public JWTAuth(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetJWTToken(string userId, string email, string role, string[] scopes)
    {
        try
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim("UserId", userId),
            new Claim("Email", email),
            new Claim(ClaimTypes.Role, role)
        };

            foreach (var scope in scopes)
            {
                claims.Add(new Claim("scope", scope));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

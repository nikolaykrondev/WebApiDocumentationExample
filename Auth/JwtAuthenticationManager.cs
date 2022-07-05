using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApiDocumentationExample.Models;

namespace WebApiDocumentationExample.Auth;

public class JwtAuthenticationManager
{
    private readonly IConfiguration _configuration;
    private readonly long _ticks;

    public JwtAuthenticationManager(IConfiguration configuration)
    {
        _configuration = configuration;
        _ticks = 86399;
    }

    public string? Authenticate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration.GetSection("TokenSecret").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.Now.AddTicks(_ticks),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            Audience = "https://localhost:7098",
            Issuer = "https://localhost:7098"
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string GetTokenLifetime()
    {
        return _ticks.ToString();
    }
}
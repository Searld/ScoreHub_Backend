using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ScoreHub_Application.Abstractions;
using ScoreHub_Domain.Entities;

namespace ScoreHub_Infrastructure.Auth;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;
    private readonly int _tgTokenLifeTime = 10;
    public string GenerateToken(Student student)
    {
        Claim[] claims =
        [
            new("userId", student.Id.ToString()),
            new(ClaimTypes.Email, student.Email)
        ];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddHours(_options.ExpiresHours));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public string GenerateTGTempToken(Guid userId)
    {
        Claim[] claims =
        [
            new("userId", userId.ToString()),
        ];
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddHours(_tgTokenLifeTime));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using ScoreHub_Application.Abstractions;

namespace ScoreHub_Infrastructure.Auth;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    public bool Verify(string hash, string password)  => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
}
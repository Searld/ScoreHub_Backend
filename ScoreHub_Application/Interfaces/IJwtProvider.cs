using ScoreHub_Domain.Entities;

namespace ScoreHub_Infrastructure;

public interface IJwtProvider
{
    public string GenerateToken(User user);
}
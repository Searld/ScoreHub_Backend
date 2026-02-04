using ScoreHub_Domain.Entities;

namespace ScoreHub_Application.Abstractions;

public interface IJwtProvider
{
    public string GenerateToken(Student student);
    public string GenerateTGTempToken(Guid userId);

}
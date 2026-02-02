namespace ScoreHub_Application.Abstractions;

public interface IJwtProvider
{
    public string GenerateToken(User user);
    public string GenerateTGTempToken(Guid userId);

}
namespace ScoreHub_Application.Users;

public interface IUserRepository
{
    public Task AddAsync(User user);
    public Task UpdateAsync(User user);
    public Task ChangeStudentScoreAsync(Guid studentId, float newScore, string subjectName);
}
using ScoreHub_Domain.Entities;

namespace ScoreHub_Domain.Repositories;

public interface IUserRepository
{
    public Task AddAsync(User user);
    public Task UpdateAsync(User user);
    public Task ChangeStudentScoreAsync(Guid studentId, float newScore, string subjectName);
}
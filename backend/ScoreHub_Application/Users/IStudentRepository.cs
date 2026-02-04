using ScoreHub_Domain.Entities;

namespace ScoreHub_Application.Users;

public interface IStudentRepository
{
    public Task AddAsync(Student student);
}
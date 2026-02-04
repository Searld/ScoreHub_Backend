using ScoreHub_Domain.Entities;

namespace ScoreHub_Application;

public interface IStudentReadDbContext
{
    public IQueryable<Student> ReadStudents { get; }
}
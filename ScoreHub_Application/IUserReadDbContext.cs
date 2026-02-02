using LessonMkn.Entities;

namespace ScoreHub_Application;

public interface IUserReadDbContext
{
    public IQueryable<User> ReadUsers { get; }
}
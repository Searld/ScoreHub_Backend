using ScoreHub_Domain.Entities;

namespace ScoreHub_Infrastructure.Repositories;

public interface ILessonRepository
{
    public Task AddAsync(Lesson lesson);
    public Task DeleteAsync(Lesson lesson);
}
using ScoreHub_Domain.Entities.MKN;

namespace ScoreHub_Application;

public interface ILessonsRepository
{
    public Task AddAsync(LessonMkn lesson);
    
}
namespace ScoreHub_Application;

public interface ILessonRepository
{
    public Task AddAsync(Lesson lesson);
    public Task DeleteAsync(Lesson lesson);
}
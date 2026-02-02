namespace ScoreHub_Application;

public interface ISubjectRepository
{
    public Task CreateSubject(Subject subject);
    public Task CreateLesson(Guid subjectId, Lesson lesson);
}
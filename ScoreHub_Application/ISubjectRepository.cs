using ScoreHub_Domain.Entities;

namespace ScoreHub_Domain.Repositories;

public interface ISubjectRepository
{
    public Task CreateSubject(Subject subject);
    public Task CreateLesson(Guid subjectId, Lesson lesson);
}
using ScoreHub_Domain.Entities;

namespace ScoreHub_Domain.Repositories;

public interface ISubjectRepository
{
    public Task CreateSubject();
    public Task<Subject> GetSubjectByName(string name);
    public Task<List<Subject>> GetAllSubjects();
}
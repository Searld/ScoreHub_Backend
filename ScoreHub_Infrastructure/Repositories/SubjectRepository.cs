using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Infrastructure.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly AppDbContext _context;

    public SubjectRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateSubject(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
    }

    public async Task<Subject> GetSubjectByName(string name)
    {
        return await _context.Subjects
            .Include(s=>s.Lessons)
            .FirstOrDefaultAsync(s => s.Name == name);
    }

    public Task<List<Subject>> GetAllSubjects()
    {
        throw new NotImplementedException();
    }
}
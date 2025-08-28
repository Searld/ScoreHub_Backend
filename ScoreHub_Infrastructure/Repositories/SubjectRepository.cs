using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Infrastructure.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly AppDbContext _context;
    private ISubjectRepository _subjectRepositoryImplementation;

    public SubjectRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateSubject(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
    }

    public async Task CreateLesson(Guid subjectId, Lesson lesson)
    {
        var subject = _context.Subjects
            .Include(s => s.Lessons)
            .FirstOrDefault(s => s.Id == subjectId);
        subject.Lessons.Add(lesson);
        _context.Subjects.Update(subject);
        await _context.SaveChangesAsync();
    }
}
using ScoreHub_Application;
using LessonMkn.Entities;

namespace ScoreHub_Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext _context;

    public LessonRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Lesson lesson)
    {
        throw new NotImplementedException();
    }
}
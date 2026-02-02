using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Users;
using LessonMkn.Entities;
using LessonMkn.Enums;
using ScoreHub_Infrastructure.Users;

namespace ScoreHub_Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeStudentScoreAsync(Guid studentId, float newScore, string subjectName)
    {
        var user = (Student)await _context.Users.FirstOrDefaultAsync(u => u.Id == studentId);
        user.SubjectScores.Where(s => s.SubjectName == subjectName).FirstOrDefault().Score = newScore;
        await UpdateAsync(user);
    }
}
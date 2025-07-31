using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;
using ScoreHub_Domain.Repositories;

namespace ScoreHub_Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByID(Guid id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetTeacherByID(Guid id)
    {
        return await _context.Users
            .Include(u=>u.TeacherData)
            .Where(u=>u.Role == Role.Teacher)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetStudentByID(Guid id)
    {
        return await _context.Users
            .Include(u=>u.StudentData)
            .Where(u=>u.Role == Role.Student)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> GetAssistantByID(Guid id)
    {
        return await _context.Users
            .Include(u=>u.AssistantData)
            .Where(u=>u.Role == Role.Assistant)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<List<User>> GetAllStudentsByGroupNumber(string groupNumber)
    {
        return await _context.Users
            .Include(u=>u.StudentData)  
            .Where(u=>u.Role == Role.Student && groupNumber == u.StudentData.GroupNumber)
            .ToListAsync();
    }
}
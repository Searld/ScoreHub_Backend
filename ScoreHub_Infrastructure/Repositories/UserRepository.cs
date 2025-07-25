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
            .Include(u => u.AssistantData)
            .Include(u => u.TeacherData)
            .Include(u => u.StudentData)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetTeacherByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetStudentByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetAssistantByID(Guid id)
    {
        throw new NotImplementedException();
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

    public async Task<List<User>> GetAllUsersByGroup(int groupNumber)
    {
        throw new NotImplementedException();
    }
}
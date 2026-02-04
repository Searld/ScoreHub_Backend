using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Users;
using ScoreHub_Domain.Entities;
using ScoreHub_Infrastructure.Users;

namespace ScoreHub_Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Student user)
    {
        await _context.Students.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student user)
    {
        _context.Students.Update(user);
        await _context.SaveChangesAsync();
    }
    
}
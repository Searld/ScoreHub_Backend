using Microsoft.EntityFrameworkCore;
using ScoreHub_Application;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Infrastructure.Users;

public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options), IStudentReadDbContext
{
    public DbSet<Student> Students { get; set; }
    public IQueryable<Student> ReadStudents => Students.AsNoTracking().AsQueryable();
    
}
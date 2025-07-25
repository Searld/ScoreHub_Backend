
using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;

namespace ScoreHub_Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TeacherData> Teachers { get; set; }
    public DbSet<AssistantData> Assistants { get; set; }
    public DbSet<StudentData> Students { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Team> Teams { get; set; }
}
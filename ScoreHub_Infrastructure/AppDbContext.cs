
using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;

namespace ScoreHub_Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Team> Teams { get; set; }
}
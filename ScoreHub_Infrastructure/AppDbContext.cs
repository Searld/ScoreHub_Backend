
using Microsoft.EntityFrameworkCore;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Entities.MKN;

namespace ScoreHub_Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Mkn> Mkns { get; set; }
    public DbSet<LessonMkn> LessonMkns { get; set; }

}
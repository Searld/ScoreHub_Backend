using Microsoft.EntityFrameworkCore;
using ScoreHub_Application;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Infrastructure.Users;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options), IUserReadDbContext

{
    public DbSet<User> Users { get; set; }
    public IQueryable<User> ReadUsers => Users.AsNoTracking().AsQueryable();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasDiscriminator<Role>(u => u.Role)
            .HasValue<Teacher>(Role.Teacher)
            .HasValue<Student>(Role.Student)
            .HasValue<Assistant>(Role.Assistant);
    }
}
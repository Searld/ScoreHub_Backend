using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScoreHub_Application;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure.Repositories;
using ScoreHub_Infrastructure.Users;

namespace ScoreHub_Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
        });
        services.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
        });
        services.AddScoped<IUserReadDbContext>(provider => 
            provider.GetRequiredService<UserDbContext>());
        
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}
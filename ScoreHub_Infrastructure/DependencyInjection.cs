using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScoreHub_Application;
using ScoreHub_Application.Abstractions;
using ScoreHub_Application.Users;
using ScoreHub_Infrastructure.Auth;
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
        services.AddDbContext<StudentDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
        });
        services.AddScoped<IStudentReadDbContext>(provider => 
            provider.GetRequiredService<StudentDbContext>());
        
        services.AddScoped<IStudentRepository, StudentRepository>();
        

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}
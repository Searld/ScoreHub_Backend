using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure.Repositories;

namespace ScoreHub_Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);
        
        return services;
    }
}
using ScoreHub_Application;
using ScoreHub_Infrastructure;

namespace ScoreHub_Backend;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);
        
        
        return services;
    }
}
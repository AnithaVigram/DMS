using DMS.Data.EF;
using DMS.Application;

namespace DMS.API;

public static class DependencyRegistration
{
    public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        // services.DataEFDependencyRegister(configuration);
        services.DataEFDependencyRegister(configuration);

        services.RepositorysDependencyRegister();

        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using DMS.Application.Interface;

namespace DMS.Application;

public static class ConfigrationRepositorys
{
    public static IServiceCollection RepositorysDependencyRegister(this IServiceCollection service)
    {
        service.AddScoped<IDMSService, DMSService>();
        service.AddScoped<IUserService, UserService>();
        return service;
    }
}

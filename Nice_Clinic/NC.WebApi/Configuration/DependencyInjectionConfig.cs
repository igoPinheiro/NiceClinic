using NC.Data.Repository;
using NC.Manager.Implementation;
using NC.Manager.Interfaces;

namespace NC.WebApi.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientManager, ClientManager>();
    }
}
//builder.Services.AddScoped<IClientRepository, ClientRepository>();
//builder.Services.AddScoped<IClientManager, ClientManager>();
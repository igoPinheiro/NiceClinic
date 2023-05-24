using Microsoft.EntityFrameworkCore;
using NC.Data.Context;

namespace NC.WebApi.Configuration;

public static class DataBaseConfig
{
    public static  void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<NCContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.CommandTimeout(60));
        });
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<NCContext>();

        context.Database.Migrate(); // é a mesmo coisa quando se realizar um update-database pelo manage console
        context.Database.EnsureCreated(); // garante que a base de dados esta criada.

    }
}

//builder.Services.AddDbContext<NCContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.CommandTimeout(60));
//});
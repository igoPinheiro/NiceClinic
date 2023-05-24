using NC.Manager.Mappings;

namespace NC.WebApi.Configuration;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(NewClientMappingProfile), typeof(UpdateClientMappingProfile));
    }
}

////builder.Services.AddAutoMapper(typeof(NewClientMappingProfile), typeof(UpdateClientMappingProfile));
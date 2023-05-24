using Microsoft.OpenApi.Models;

namespace NC.WebApi.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Consultório Legal",
                    Version = "v1",
                    Description = "API da aplicação consultório legal",
                    Contact = new OpenApiContact
                    {
                        Name = "Igo Pinheiro",
                        Email = "igo.pinheiro1@gmail.com",
                        Url = new Uri("https://github.com/igoPinheiro")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://github.com/igoPinheiro/NiceClinic")
                    },
                    TermsOfService = new Uri("https://github.com/igoPinheiro/NiceClinic")

                });
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}

using Microsoft.OpenApi.Models;
using System.Reflection;

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

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);

            c.IncludeXmlComments(xmlPath);

            xmlPath = Path.Combine(AppContext.BaseDirectory, "NC.Core.Shared.xml");
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}

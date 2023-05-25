using NC.WebApi.Configuration;
using Serilog;

IConfigurationRoot configuration = LogConfig();

ConfigLog(configuration);

try
{
    Log.Information("Iniciando Web Api");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();


    // Add services to the container.
    builder.Services.AddControllers();

    builder.Services.AddFluentValidationConfiguration();

    builder.Services.AddAutoMapperConfiguration();

    builder.Services.AddDatabaseConfiguration(builder.Configuration);

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    builder.Services.AddDependencyInjectionConfiguration();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerConfiguration();

    var app = builder.Build();

    app.UseDatabaseConfiguration();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerConfiguration();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{

    Log.Fatal(ex, "Erro Catastrofico");
}
finally
{
    Log.CloseAndFlush();
}

static IConfigurationRoot LogConfig()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json")
        .Build();
    return configuration;
}

static void ConfigLog(IConfigurationRoot configuration)
{
    Log.Logger = new LoggerConfiguration()
       .ReadFrom.Configuration(configuration)
       .CreateLogger();


    //.WriteTo.File("log.txt",fileSizeLimitBytes: 100000) // limitando a 100KB. Quando atingir 100Kb, ele apaga os log mais antigos, para dar espaçõ aos logs mais novos. 
    //  .WriteTo.File("log.txt", fileSizeLimitBytes: 100000, rollOnFileSizeLimit:true) // Cria um novo arquivo a casa 100KB
    //.WriteTo.File("log.txt", fileSizeLimitBytes: 100000, rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day) // Cria um arquivo por dia se esse arquivo nesse dia chegar a 100kb ele cria outro

}
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NC.Data.Context;
using NC.Data.Repository;
using NC.Manager.Implementation;
using NC.Manager.Interfaces;
using NC.Manager.Mappings;
using NC.Manager.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
   //.AddFluentValidation(options =>
   //{
   //    // Validate child properties and root collection elements
   //    options.ImplicitlyValidateChildProperties = true;
   //    options.ImplicitlyValidateRootCollectionElements = true;

   //    // Automatic registration of validators in assembly
   //    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
   //});
   .AddFluentValidation(config =>
   {
       config.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
       config.RegisterValidatorsFromAssemblyContaining<UpdateClientValidator>();
       config.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
   });

builder.Services.AddAutoMapper(typeof(NewClientMappingProfile), typeof(UpdateClientMappingProfile));

builder.Services.AddDbContext<NCContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.CommandTimeout(60));
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientManager, ClientManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using FluentValidation.AspNetCore;
using NC.Core.Shared.ModelViews;
using NC.Manager.Validator;

namespace NC.WebApi.Configuration;

public static class FluentValidationConfiguration
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {

        services.AddFluentValidation(config =>
           {
               config.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
               config.RegisterValidatorsFromAssemblyContaining<UpdateClientValidator>();
               config.RegisterValidatorsFromAssemblyContaining<NewAddressValidator>();
               config.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
           });
    }
}


////.AddFluentValidation(options =>
////{
////    // Validate child properties and root collection elements
////    options.ImplicitlyValidateChildProperties = true;
////    options.ImplicitlyValidateRootCollectionElements = true;

////    // Automatic registration of validators in assembly
////    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
////});
//.AddFluentValidation(config =>
//{
//    config.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
//    config.RegisterValidatorsFromAssemblyContaining<UpdateClientValidator>();
//    config.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("pt-BR");
//});

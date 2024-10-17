using HobHub.API.Middlewares;
using JobHub.Application.DependencyConfigurationExtension;
using Microsoft.OpenApi.Models;

namespace HobHub.API.ServiceConfigurations;


public static class HttpServicesPilelineConfiguration
{
    public static void ServicesPilelineConfiguration(this WebApplicationBuilder builder)
    {
        RegisterServicesConfiguration(builder);
        RegisterServices(builder);
    }

    private static void RegisterServices(WebApplicationBuilder builder)
    {
        // Register application layer services
        builder.Services.AddServicesDependencyConfiguration();
    }

    private static void RegisterServicesConfiguration(WebApplicationBuilder builder)
    {
        // Build in services

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        SwaggerConfiguration(builder);

        //health checks
        builder.Services.AddHealthChecks();

        //Exception Handeler
        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    }

    private static void SwaggerConfiguration(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Book Service API",
                Version = "v1",
                Description = "API for managing Jobs",
            });

        });
    }

}
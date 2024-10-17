using JobHub.Application.IServices;
using JobHub.Application.Services;
using JobHub.Domain.IRepositories;
using JobHub.Infrastructure.Repositoreis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobHub.Application.DependencyConfigurationExtension;


public static class ServiceDependencyConfigurationExtension
{
    public static IServiceCollection AddServicesDependencyConfiguration(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());

        AddBussinessDIConfiguration(services);
        AddDataDIConfiguration(services);
        return services;
    }

    private static IServiceCollection AddDataDIConfiguration(IServiceCollection services)
    {
        // Data
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        return services;
    }

    private static IServiceCollection AddBussinessDIConfiguration(IServiceCollection services)
    {
        // Business
        services.AddScoped<ICandidateService, CandidateService>();
        return services;
    }
}
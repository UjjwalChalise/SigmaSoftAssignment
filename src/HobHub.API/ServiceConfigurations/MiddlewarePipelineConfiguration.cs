﻿using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json;

namespace HobHub.API.ServiceConfigurations;


public static class MiddlewarePipelineConfiguration
{
    public static void MiddleWarePipelIne(this WebApplication app)
    {
        MiddlewareConfiguration(app);
        HealthCheckMiddlewareConfiguration(app);
    }

    private static void MiddlewareConfiguration(WebApplication app)
    {
        app.UseStatusCodePages();
        app.UseExceptionHandler();

        SwaggerMiddlewareConfiguration(app);

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

    }

    private static void SwaggerMiddlewareConfiguration(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Service API V1");
            });
        }
    }

    private static void HealthCheckMiddlewareConfiguration(WebApplication app)
    {
        // Health check Middleware configuration
        app.MapHealthChecks("/jobhubservice-health", new HealthCheckOptions()
        {
            ResponseWriter = async (context, report) =>
            {
                var result = JsonSerializer.Serialize(
                    new
                    {
                        status = report.Status.ToString(),
                        checks = report.Entries.Select(entry => new
                        {
                            name = entry.Key.ToString(),
                            status = entry.Value.Status.ToString(),
                            exception = entry.Value.Exception is not null ? entry.Value.Exception.Message : "none",
                            duration = entry.Value.Duration.ToString()
                        })
                    });

                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(result);
            }
        });
    }
}

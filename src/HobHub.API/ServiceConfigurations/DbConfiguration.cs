using JobHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HobHub.API.ServiceConfigurations;


public static class DbConfiguration
{
    public static void RegisterDbConfiguration(this WebApplicationBuilder builder)
    {
        // Add DbContext Service
        builder.Services.AddDbContext<JobHubApplicationDbContext>(options => options
                    .UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

    }


}

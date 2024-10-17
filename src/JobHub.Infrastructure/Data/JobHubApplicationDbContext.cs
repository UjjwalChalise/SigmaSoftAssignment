using JobHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobHub.Infrastructure.Data;

public class JobHubApplicationDbContext : DbContext
{
    public JobHubApplicationDbContext( DbContextOptions<JobHubApplicationDbContext> options) : base(options)
    {
        
    }

    // DbSets
    public DbSet<Candidate> Candidates { get; set; }
}

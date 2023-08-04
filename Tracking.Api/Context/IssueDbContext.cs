using Microsoft.EntityFrameworkCore;
using Tracking.Api.Models;

namespace Tracking.Api.Context
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options)    
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CallsLogSummary> CallsLogSummary { get; set; }
        public DbSet<CallsLogDetails> CallsLogDetails { get; set; }


    }
}

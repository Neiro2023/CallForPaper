using CFP.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Application
{
    public class CallForPaperContext : DbContext
    {
        public DbSet<CallForPaper> CallForPapers { get; set; }

        public CallForPaperContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Username=postgres;Password=1234;Host=localhost;Port=5432;Database=CFPDb;Trust Server Certificate=true;Pooling=true;");
        }
    }
}

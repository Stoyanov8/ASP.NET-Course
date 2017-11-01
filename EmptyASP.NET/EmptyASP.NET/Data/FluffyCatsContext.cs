namespace EmptyASP.NET.Data
{
    using Microsoft.EntityFrameworkCore;

    public class FluffyCatsContext : DbContext
    {
        public FluffyCatsContext(DbContextOptions<FluffyCatsContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
using ddd.Data.Configurations;
using ddd.Domain;
using Microsoft.EntityFrameworkCore;

namespace ddd.Data
{
    public class DronContext : DbContext
    {
        public DbSet<Dron> Drons { get; set; }
        
        public DronContext(DbContextOptions<DronContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DronConfiguration());
        }
    }
}
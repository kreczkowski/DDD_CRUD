using ddd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ddd.Data.Configurations
{
    public class DronConfiguration : IEntityTypeConfiguration<Dron>
    {
        public void Configure(EntityTypeBuilder<Dron> builder)
        {
           
        }
    }
}

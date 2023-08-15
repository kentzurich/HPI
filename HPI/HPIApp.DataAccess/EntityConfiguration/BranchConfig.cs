using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<Branch> modelBuilder)
        {
            modelBuilder.HasData(
                   new Branch
                   {
                       Id = 1,
                       Name = "Nueva Ecija"
                   },
                   new Branch
                   {
                       Id = 2,
                       Name = "Cavite"
                   }
               );
        }
    }
}

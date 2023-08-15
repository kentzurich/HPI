using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class ClassConfig : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<Class> modelBuilder)
        {
            modelBuilder.HasData(
                    new Class
                    {
                        Id = 1,
                        Name = "Cluster A",
                        BranchId = 1,
                        Slot = 3000
                    },
                    new Class
                    {
                        Id = 2,
                        Name = "Cluster B",
                        BranchId = 1,
                        Slot = 3000
                    },
                    new Class
                    {
                        Id = 3,
                        Name = "Cluster A",
                        BranchId = 2,
                        Slot = 3000
                    }
                );
        }
    }
}

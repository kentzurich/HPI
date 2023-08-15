using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class ReligionConfig : IEntityTypeConfiguration<Religion>
    {
        public void Configure(EntityTypeBuilder<Religion> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<Religion> modelBuilder)
        {
            modelBuilder.HasData(
                    new Religion
                    {
                        Id = 1,
                        Name = "Seventh Day Adventist"
                    },
                    new Religion
                    {
                        Id = 2,
                        Name = "Others"
                    }
                );
        }
    }
}

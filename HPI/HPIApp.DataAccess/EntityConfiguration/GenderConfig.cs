using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<Gender> modelBuilder)
        {
            modelBuilder.HasData(
                    new Gender { Id = 1, Name = "Male", },
                    new Gender { Id = 2, Name = "Female", }
                );
        }
    }
}

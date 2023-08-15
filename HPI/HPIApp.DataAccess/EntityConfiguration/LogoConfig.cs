using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class LogoConfig : IEntityTypeConfiguration<Logo>
    {
        public void Configure(EntityTypeBuilder<Logo> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<Logo> modelBuilder)
        {
            modelBuilder.HasData(
                    new Logo
                    {
                        Id = 1,
                        logoUrl = "\\img\\logo\\9d4cc6e7-4ea9-4724-8a3b-782d525c3844.png",
                        textLogo = "HIM Plus International"
                    }
                );
        }
    }
}

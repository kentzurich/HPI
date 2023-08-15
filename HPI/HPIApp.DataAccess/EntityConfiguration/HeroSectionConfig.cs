using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class HeroSectionConfig : IEntityTypeConfiguration<HeroSection>
    {
        public void Configure(EntityTypeBuilder<HeroSection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<HeroSection> modelBuilder)
        {
            modelBuilder.HasData(
                    new HeroSection
                    {
                        Id = 1,
                        Header1 = "HPI",
                        Header2 = "HIM Plus International",
                        backgroundImgUrl = "\\img\\herosection\\2a3a35a4-4544-48b9-9066-6ac4d279ebcf.jpg"
                    }
                );
        }
    }
}

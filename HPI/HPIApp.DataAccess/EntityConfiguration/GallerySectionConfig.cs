using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class GallerySectionConfig : IEntityTypeConfiguration<GallerySection>
    {
        public void Configure(EntityTypeBuilder<GallerySection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<GallerySection> modelBuilder)
        {
            modelBuilder.HasData(
                    new GallerySection
                    {
                        Id = 1,
                        ImgUrl = "https://placehold.co/800x600/png"
                    },
                    new GallerySection
                    {
                        Id = 2,
                        ImgUrl = "https://placehold.co/800x600/png"
                    },
                    new GallerySection
                    {
                        Id = 3,
                        ImgUrl = "https://placehold.co/800x600/png"
                    }
                );
        }
    }
}

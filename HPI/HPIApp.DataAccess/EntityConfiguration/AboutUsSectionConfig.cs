using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class AboutUsSectionConfig : IEntityTypeConfiguration<AboutUsSection>
    {
        public void Configure(EntityTypeBuilder<AboutUsSection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<AboutUsSection> modelBuilder)
        {
            modelBuilder.HasData(
                    new AboutUsSection
                    {
                        Id = 1,
                        VideoUrl = "https://www.youtube.com/watch?v=uCPjdfCUowg&list=RDpe5H8xY2pyY&index=6",
                        VideoBoxUrl = "https://placehold.co/1024x692/png",
                        mainContentTitle = "About Us",
                        mainContentDescription = "The Healing Ministry is a non-profit organization dedicated to providing healing and hope to those who are hurting. We offer a variety of services, including prayer, counseling, and support groups. We believe that everyone deserves to experience the healing power of God.",
                        contentTitle_1 = "Prayer",
                        contentDescription_1 = "We believe that prayer is a powerful tool for healing. We offer prayer for those who are seeking physical, emotional, or spiritual healing.",
                        contentTitle_2 = "Counseling",
                        contentDescription_2 = "We offer counseling to help people deal with the challenges of life. We believe that counseling can help people to heal from emotional wounds and to find hope for the future.",
                        contentTitle_3 = "Support groups",
                        contentDescription_3 = "We offer support groups for people who are dealing with specific challenges, such as grief, addiction, or chronic illness. We believe that support groups can provide a safe place for people to share their experiences and to find support from others who understand what they are going through."
                    }
                );
        }
    }
}

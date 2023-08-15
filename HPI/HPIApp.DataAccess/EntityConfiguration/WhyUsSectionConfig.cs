using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class WhyUsSectionConfig : IEntityTypeConfiguration<WhyUsSection>
    {
        public void Configure(EntityTypeBuilder<WhyUsSection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<WhyUsSection> modelBuilder)
        {
            modelBuilder.HasData(
                    new WhyUsSection
                    {
                        Id = 1,
                        mainContentTitle = "Why HPI?",
                        mainContentDescription = "We are a ministry dedicated to providing healing and hope to those who are hurting. We offer a variety of services, including prayer, counseling, and support groups. We believe that everyone deserves to experience the healing power of God.",
                        contentTitle_1 = "Healing Prayer",
                        contentDescription_1 = "We offer healing prayer to those who are seeking physical, emotional, or spiritual healing. We believe that God has the power to heal all kinds of sickness and disease. We invite you to come and experience the healing power of God through prayer.",
                        contentTitle_2 = "Healing Touch",
                        contentDescription_2 = "We offer healing touch to those who are seeking physical, emotional, or spiritual healing. Healing touch is a gentle, non-invasive form of energy healing that can help to promote relaxation, reduce pain, and improve overall well-being. We invite you to come and experience the healing power of God through healing touch.",
                        contentTitle_3 = "Laying on of Hands",
                        contentDescription_3 = "We offer laying on of hands to those who are seeking physical, emotional, or spiritual healing. Laying on of hands is a biblical practice that has been used for centuries to pray for healing. We believe that God can use this simple act to bring healing to those who are hurting. We invite you to come and experience the healing power of God through laying on of hands."
                    }
                );
        }
    }
}

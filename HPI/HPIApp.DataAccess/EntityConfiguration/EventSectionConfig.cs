using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class EventSectionConfig : IEntityTypeConfiguration<EventsSection>
    {
        public void Configure(EntityTypeBuilder<EventsSection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<EventsSection> modelBuilder)
        {
            modelBuilder.HasData(
                    new EventsSection
                    {
                        Id = 1,
                        EventDescription = "Healing services: Healing services are typically held in churches or other religious settings. They involve prayer, worship, and sometimes the laying on of hands.\r\n\r\nHealing conferences: Healing conferences are typically held over a weekend or a week. They feature speakers, workshops, and other activities that focus on healing.\r\n\r\nHealing retreats: Healing retreats are typically held in a quiet setting, such as a camp or a retreat center. They offer participants the opportunity to relax, pray, and receive healing.\r\n\r\nHealing prayer groups: Healing prayer groups are typically held on a weekly or monthly basis. They provide a safe place for people to come together to pray for healing.\r\n\r\nHealing ministries: Healing ministries are typically run by individuals or organizations that are dedicated to providing healing to those who are hurting. They offer a variety of services, such as prayer, counseling, and support groups."
                    }
                );
        }
    }
}

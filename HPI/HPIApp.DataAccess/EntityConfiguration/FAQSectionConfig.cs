using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class FAQSectionConfig : IEntityTypeConfiguration<FAQSection>
    {
        public void Configure(EntityTypeBuilder<FAQSection> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<FAQSection> modelBuilder)
        {
            modelBuilder.HasData(
                    new FAQSection
                    {
                        Id = 1,
                        Question = "Mabilis lang ba matanggap Ang assistance?",
                        Answer = "oo dahil paperless and validation at online remittance lamang Ang proseso. Matagal na Ang 2 days"
                    },
                    new FAQSection
                    {
                        Id = 2,
                        Question = "Pwede pa bang bumalik kung matagal nang huminto sa",
                        Answer = "oo subalit mag aaply muli Ng registration at magbabayad Ng registration fee na P120.00 at initial monthly fund na P150.00"
                    },
                    new FAQSection
                    {
                        Id = 3,
                        Question = "Ano pwede Gawin kung gusto bumalik maging active?",
                        Answer = "mag apply Ng activation status at magbayad Ng activation fee na P50 at bayaran Ang di nahulugan."
                    }
                );
        }
    }
}

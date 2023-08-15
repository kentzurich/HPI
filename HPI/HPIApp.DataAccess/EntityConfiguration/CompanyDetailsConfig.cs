using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HPIApp.DataAccess.EntityConfiguration
{
    public class CompanyDetailsConfig : IEntityTypeConfiguration<CompanyDetails>
    {
        public void Configure(EntityTypeBuilder<CompanyDetails> modelBuilder)
        {
            SeedEntity(modelBuilder);
        }

        private void SeedEntity(EntityTypeBuilder<CompanyDetails> modelBuilder)
        {
            modelBuilder.HasData(
                    new CompanyDetails
                    {
                        Id = 1,
                        Address = "Palo Maria, Bongabon, Nueva Ecija",
                        Email = "himplusinternational@gmail.com",
                        PhoneNo = "+63 915 4094657"
                    }
                );
        }
    }
}

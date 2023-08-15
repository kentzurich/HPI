using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyFAQSection
{
    public interface IFAQSectionRepository : IGenericRepository<FAQSection>
    {
        Task Update(FAQSection obj);
    }
}

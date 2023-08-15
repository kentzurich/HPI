using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyWhyUsSection
{
    public interface IWhyUsSectionRepository : IGenericRepository<WhyUsSection>
    {
        Task Update(WhyUsSection obj);
    }
}

using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyAboutUsSection
{
    public interface IAboutUsSectionRepository : IGenericRepository<AboutUsSection>
    {
        Task Update(AboutUsSection obj);
    }
}

using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyHeroSection
{
    public interface IHeroSectionRepository : IGenericRepository<HeroSection>
    {
        Task Update(HeroSection obj);
    }
}

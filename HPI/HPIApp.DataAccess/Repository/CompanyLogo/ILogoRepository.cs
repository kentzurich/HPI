using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyLogo
{
    public interface ILogoRepository : IGenericRepository<Logo>
    {
        Task Update(Logo obj);
    }
}

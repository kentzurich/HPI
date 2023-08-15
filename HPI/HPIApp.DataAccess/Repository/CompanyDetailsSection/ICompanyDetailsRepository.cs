using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyDetailsSection
{
    public interface ICompanyDetailsRepository : IGenericRepository<CompanyDetails>
    {
        Task Update(CompanyDetails obj);
    }
}

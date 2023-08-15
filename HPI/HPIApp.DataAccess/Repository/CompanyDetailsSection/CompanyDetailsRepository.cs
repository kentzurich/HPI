using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyDetailsSection
{
    public class CompanyDetailsRepository : GenericRepository<CompanyDetails>, ICompanyDetailsRepository
    {
        private readonly ApplicationDBContext _db;
        public CompanyDetailsRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(CompanyDetails obj)
        {
            _db.Update(obj);
        }
    }
}

using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyLogo
{
    public class LogoRepository : GenericRepository<Logo>, ILogoRepository
    {
        private readonly ApplicationDBContext _db;
        public LogoRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(Logo obj)
        {
            _db.Update(obj);
        }
    }
}

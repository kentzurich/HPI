using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyWhyUsSection
{
    public class WhyUsSectionRepository : GenericRepository<WhyUsSection>, IWhyUsSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public WhyUsSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(WhyUsSection obj)
        {
            _db.Update(obj);
        }
    }
}

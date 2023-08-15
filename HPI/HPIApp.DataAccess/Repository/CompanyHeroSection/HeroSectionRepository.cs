using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyHeroSection
{
    public class HeroSectionRepository : GenericRepository<HeroSection>, IHeroSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public HeroSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(HeroSection obj)
        {
            _db.Update(obj);
        }
    }
}

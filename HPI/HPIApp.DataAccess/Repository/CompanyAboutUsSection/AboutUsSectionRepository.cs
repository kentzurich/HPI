using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyAboutUsSection
{
    public class AboutUsSectionRepository : GenericRepository<AboutUsSection>, IAboutUsSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public AboutUsSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(AboutUsSection obj)
        {
            _db.Update(obj);
        }
    }
}

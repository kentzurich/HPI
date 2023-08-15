using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyFAQSection
{
    public class FAQSectionRepository : GenericRepository<FAQSection>, IFAQSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public FAQSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(FAQSection obj)
        {
            _db.Update(obj);
        }
    }
}

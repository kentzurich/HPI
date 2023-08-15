using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyContactSection
{
    public class ContactSectionRepository : GenericRepository<ContactSection>, IContactSectionRepository
    {
        private readonly ApplicationDBContext _db;

        public ContactSectionRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }
        public async Task Update(ContactSection obj)
        {
            _db.Update(obj);
        }
    }
}

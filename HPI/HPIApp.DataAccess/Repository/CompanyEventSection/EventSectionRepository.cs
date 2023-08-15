using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyEventSection
{
    public class EventSectionRepository : GenericRepository<EventsSection>, IEventSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public EventSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(EventsSection obj)
        {
            _db.Update(obj);
        }
    }
}

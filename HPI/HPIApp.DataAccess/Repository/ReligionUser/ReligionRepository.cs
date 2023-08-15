using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.ReligionUser
{
    public class ReligionRepository : GenericRepository<Religion>, IReligionRepository
    {
        private readonly ApplicationDBContext _db;
        public ReligionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(Religion obj)
        {
            _db.Religion.Update(obj);
        }
    }
}

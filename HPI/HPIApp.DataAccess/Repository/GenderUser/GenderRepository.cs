using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.GenderUser
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        private readonly ApplicationDBContext _db;
        public GenderRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Models.Gender obj)
        {
            _db.Gender.Update(obj);
        }
    }
}

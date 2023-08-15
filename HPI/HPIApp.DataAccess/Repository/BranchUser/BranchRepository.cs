using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.BranchUser
{
    internal class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly ApplicationDBContext _db;
        public BranchRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(Branch obj)
        {
            _db.Update(obj);
        }
    }
}

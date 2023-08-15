using HPIApp.DataAccess.Data;
using HPIApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace HPIApp.DataAccess.Repository.ClassUser
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly ApplicationDBContext _db;
        public ClassRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SelectListItem>> GetClassAsync(int branchId)
        {
            var classList = await _db.Class.Where(x => x.Slot > 0 && x.BranchId == branchId).Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }).ToListAsync();

            return classList;
        }

        public async Task<int> DecrementCount(Class obj, int count)
        {
            obj.Slot -= count;
            return obj.Slot;
        }

        public async Task Update(Class obj)
        {
            _db.Class.Update(obj);
        }
    }
}

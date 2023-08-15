using HPIApp.Models;
using System.Web.Mvc;

namespace HPIApp.DataAccess.Repository.ClassUser
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task Update(Class obj);
        Task<int> DecrementCount(Class obj, int count);
        Task<IEnumerable<SelectListItem>> GetClassAsync(int branchId);
    }
}

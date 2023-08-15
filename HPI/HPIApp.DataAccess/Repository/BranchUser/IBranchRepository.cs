using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.BranchUser
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task Update(Branch obj);
    }
}

using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.GenderUser
{
    public interface IGenderRepository : IGenericRepository<Gender>
    {
        Task Update(Gender obj);
    }
}

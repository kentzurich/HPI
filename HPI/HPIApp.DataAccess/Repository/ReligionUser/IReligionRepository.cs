using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.ReligionUser
{
    public interface IReligionRepository : IGenericRepository<Religion>
    {
        Task Update(Religion obj);
    }
}
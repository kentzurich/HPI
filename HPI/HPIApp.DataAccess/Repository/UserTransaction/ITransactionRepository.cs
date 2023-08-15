using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.UserTransaction
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task Update(Transaction transaction);
    }
}

using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.UserTransaction
{
    internal class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDBContext _db;
        public TransactionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Transaction transaction)
        {
            _db.Update(transaction);
        }
    }
}

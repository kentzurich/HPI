using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.PaymentMethodUser
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly ApplicationDBContext _db;
        public PaymentMethodRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(PaymentMethod obj)
        {
            _db.PaymentMethod.Update(obj);
        }
    }
}

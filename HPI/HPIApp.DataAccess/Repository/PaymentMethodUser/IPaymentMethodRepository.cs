using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.PaymentMethodUser
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod>
    {
        Task Update(PaymentMethod obj);
    }
}

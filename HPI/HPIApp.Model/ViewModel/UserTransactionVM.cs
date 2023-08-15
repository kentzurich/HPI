using Microsoft.AspNetCore.Mvc.Rendering;

namespace HPIApp.Models.ViewModel
{
    public class UserTransactionVM
    {
        public ApplicationUser applicationUser { get; set; }
        public Transaction transaction { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public IEnumerable<SelectListItem> userStatus { get; set; }
    }
}

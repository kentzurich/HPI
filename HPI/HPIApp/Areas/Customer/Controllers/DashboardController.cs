using HPIApp.DataAccess.Repository;
using HPIApp.Models.ViewModel;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace HPIApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = StaticDetails.ROLE_CUSTOMER)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var claim = _unitOfWork.ApplicationUser.GetUserClaims((ClaimsIdentity)User.Identity).GetAwaiter().GetResult().Value;
            UserTransactionVM userTransactionVM = new();

            userTransactionVM.transaction = await _unitOfWork
                .Transaction
                .GetFirstOrDefaultAsync(x => 
                x.ApplicationUserId == claim && 
                x.TransactionType == StaticDetails.PAYMENTTYPE_REGISTRATION);

            return View(userTransactionVM);
        }
    }
}

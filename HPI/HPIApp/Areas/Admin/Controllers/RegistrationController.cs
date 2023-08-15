using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Models.ViewModel;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "registration", navItem = "transaction" };
            return View();
        }

        public async Task<IActionResult> RegistrationApproval(int Id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "registration", navItem = "transaction" };

            UserTransactionVM userTransactionVM = new();

            userTransactionVM.transaction = await _unitOfWork
                .Transaction
                .GetFirstOrDefaultAsync(x => x.Id == Id);

            if (userTransactionVM.transaction is null)
                return View("_Error404");

            userTransactionVM.applicationUser = await _unitOfWork
                .ApplicationUser
                .GetFirstOrDefaultAsync(x => x.Id == userTransactionVM.transaction.ApplicationUserId);

            userTransactionVM.paymentMethod = await _unitOfWork
                .PaymentMethod
                .GetFirstOrDefaultAsync(x => x.Id == userTransactionVM.transaction.PaymentMethodId);

            userTransactionVM.userStatus = new List<SelectListItem>
            {
                new SelectListItem { Value = StaticDetails.USERSTATUS_PENDING, Text = StaticDetails.USERSTATUS_PENDING },
                new SelectListItem { Value = StaticDetails.USERSTATUS_APPROVED, Text = StaticDetails.USERSTATUS_APPROVED }
            };

            return View(userTransactionVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationApproval(UserTransactionVM userTransactionVM)
        {
            await _unitOfWork.Transaction.Update(userTransactionVM.transaction);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Payment Status successfully updated.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrationTxn(int branchId)
        {
            var txnList = await _unitOfWork
                .Transaction
                .GetAllAsync(x => 
                x.TransactionType == StaticDetails.PAYMENTTYPE_REGISTRATION, 
                includeProperties: "ApplicationUser,PaymentMethod");
            return Json(new { data = txnList });
        }
    }
}

using EntityFramework.Exceptions.Common;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class PaymentMethodController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentMethodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "paymentMethod", navItem = "contentManagement" };
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "paymentMethod", navItem = "userManagement" };

            PaymentMethod obj = new();

            if (id is null || id.Equals(0))
                return View(obj);

            obj = await _unitOfWork.PaymentMethod.GetFirstOrDefaultAsync(x => x.Id == id);

            if (obj is null)
                return View("_Error404");

            return View(obj);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PaymentMethod obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id.Equals(0))
                {
                    await _unitOfWork.PaymentMethod.AddAsync(obj);
                    TempData["success"] = "Payment Method created successfully.";
                }
                else
                {
                    await _unitOfWork.PaymentMethod.Update(obj);
                    TempData["success"] = "Payment Method updated successfully.";
                }

                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var PaymentMethodObj = await _unitOfWork.PaymentMethod.GetFirstOrDefaultAsync(x => x.Id == id);

                if (PaymentMethodObj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.PaymentMethod.Remove(PaymentMethodObj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Payment Method deleted successfully." });
            }
            catch (ReferenceConstraintException ex)
            {
                return Json(new { error = true, message = "Error while deleting. " + ex.Message });
            }
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paymentMethodList = await _unitOfWork.PaymentMethod.GetAllAsync();
            return Json(new { data = paymentMethodList });
        }
        #endregion
    }
}

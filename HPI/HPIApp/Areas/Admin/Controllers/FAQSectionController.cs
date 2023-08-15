using EntityFramework.Exceptions.Common;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class FAQSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FAQSectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "faqSection", navItem = "contentManagement" };
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "faqSection", navItem = "contentManagement" };

            FAQSection FAQSection = new();

            if (id is null || id.Equals(0))
                return View(FAQSection);

            FAQSection = await _unitOfWork.FAQSection.GetFirstOrDefaultAsync(x => x.Id == id);

            if (FAQSection is null)
                return View("_Error404");

            return View(FAQSection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(FAQSection obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id.Equals(0))
                {
                    await _unitOfWork.FAQSection.AddAsync(obj);
                    TempData["success"] = "Frequently Asked Questions created successfully.";
                }
                else
                {
                    await _unitOfWork.FAQSection.Update(obj);
                    TempData["success"] = "Frequently Asked Questions updated successfully.";
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
                var obj = await _unitOfWork.FAQSection.GetFirstOrDefaultAsync(x => x.Id == id);

                if (obj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.FAQSection.Remove(obj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Frequently Asked Questions deleted successfully." });
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
            var faqList = await _unitOfWork.FAQSection.GetAllAsync();
            return Json(new { data = faqList });
        }
        #endregion
    }
}

using EntityFramework.Exceptions.Common;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class ReligionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReligionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "religion", navItem = "contentManagement" };
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "religion", navItem = "contentManagement" };

            Religion obj = new();

            if (id is null || id.Equals(0))
                return View(obj);

            obj = await _unitOfWork.Religion.GetFirstOrDefaultAsync(x => x.Id == id);

            if (obj is null)
                return View("_Error404");

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Religion obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id.Equals(0))
                {
                    await _unitOfWork.Religion.AddAsync(obj);
                    TempData["success"] = "Religion created successfully.";
                }
                else
                {
                    await _unitOfWork.Religion.Update(obj);
                    TempData["success"] = "Religion updated successfully.";
                }

                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var religionObj = await _unitOfWork.Religion.GetFirstOrDefaultAsync(x => x.Id == id);

                if (religionObj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.Religion.Remove(religionObj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Religion deleted successfully." });
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
            var religionList = await _unitOfWork.Religion.GetAllAsync();
            return Json(new { data = religionList });
        }
        #endregion
    }
}

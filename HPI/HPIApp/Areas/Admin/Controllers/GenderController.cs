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
    public class GenderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "gender", navItem = "contentManagement" };
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "gender", navItem = "contentManagement" };

            Gender obj = new();

            if (id is null || id.Equals(0))
                return View(obj);

            obj = await _unitOfWork.Gender.GetFirstOrDefaultAsync(x => x.Id == id);

            if(obj is null)
                return View("_Error404");

            return View(obj);
        }

        //POST Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Gender obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id.Equals(0))
                {
                    await _unitOfWork.Gender.AddAsync(obj);
                    TempData["success"] = "Gender created successfully.";
                }
                else
                {
                    await _unitOfWork.Gender.Update(obj);
                    TempData["success"] = "Gender updated successfully.";
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
                var genderObj = await _unitOfWork.Gender.GetFirstOrDefaultAsync(x => x.Id == id);

                if (genderObj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.Gender.Remove(genderObj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Gender deleted successfully." });
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
            var genderList = await _unitOfWork.Gender.GetAllAsync();
            return Json(new { data = genderList });
        }
        #endregion
    }
}

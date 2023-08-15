using EntityFramework.Exceptions.Common;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Models.ViewModel;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
        public async Task<IActionResult> Create(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "Class", navItem = "contentManagement" };

            BranchClassVM branchClassVM = new();

            if (id is null || id.Equals(0))
                return View(branchClassVM.Branch);

            branchClassVM.Branch = await _unitOfWork.Branch.GetFirstOrDefaultAsync(x => x.Id == id);

            if (branchClassVM is null)
                return View("_Error404");

            return View(branchClassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
        public async Task<IActionResult> Create(BranchClassVM obj)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "branch", navItem = "contentManagement" };

            if (ModelState.IsValid)
            {
                obj.Class.BranchId = obj.Branch.Id;
                await _unitOfWork.Class.AddAsync(obj.Class);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Class created successfully.";
                return RedirectToAction("Upsert", "Branch", new { Id = obj.Branch.Id });
            }
            else return View(obj);
        }

        [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "Class", navItem = "contentManagement" };

            if (id is null || id.Equals(0))
                return View("_Error404");
            else
            {
                Class Class = await _unitOfWork.Class.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "Branch");

                if (Class is null)
                    return View("_Error404");

                return View(Class);
            }
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
        public async Task<IActionResult> Edit(Class obj)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "Class", navItem = "contentManagement" };
            if (ModelState.IsValid)
            {
                await _unitOfWork.Class.Update(obj);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Class updated successfully.";
                return RedirectToAction("Upsert", "Branch", new { Id = obj.Branch.Id });
            }
            else 
                return View(obj);
        }

        [HttpDelete]
        [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var obj = await _unitOfWork.Class.GetFirstOrDefaultAsync(x => x.Id == id);

                if (obj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.Class.Remove(obj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Class deleted successfully." });
            }
            catch (ReferenceConstraintException ex)
            {
                return Json(new { error = true, message = "Error while deleting. " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClass(int branchId)
        {
            var classList = await _unitOfWork.Class.GetClassAsync(branchId);
            return Json(new { data = classList });
        }
    }
}

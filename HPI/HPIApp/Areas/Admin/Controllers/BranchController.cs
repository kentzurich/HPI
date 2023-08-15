using EntityFramework.Exceptions.Common;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class BranchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BranchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "branch", navItem = "contentManagement" };
            return View();
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "branch", navItem = "contentManagement" };

            Branch branch = new();

            if (id is null || id.Equals(0))
                return View(branch);

            branch = await _unitOfWork.Branch.GetFirstOrDefaultAsync(x => x.Id == id);

            if (branch is null)
                return View("_Error404");

            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Branch obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id.Equals(0))
                {
                    await _unitOfWork.Branch.AddAsync(obj);
                    TempData["success"] = "Branch created successfully.";
                }
                else
                {
                    await _unitOfWork.Branch.Update(obj);
                    TempData["success"] = "Branch updated successfully.";
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
                var obj = await _unitOfWork.Branch.GetFirstOrDefaultAsync(x => x.Id == id);

                if (obj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.Branch.Remove(obj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Branch deleted successfully." });
            }
            catch (ReferenceConstraintException ex)
            {
                return Json(new { error = true, message = "Error while deleting. " + ex.Message });
            }
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            var branchList = await _unitOfWork.Branch.GetAllAsync();
            return Json(new { data = branchList });
        }
        [HttpGet]
        //[Route("Admin/Branch/Upsert/{branchId:int}")]
        public async Task<IActionResult> GetAllClass(int id)
        {
            var classList = await _unitOfWork.Class.GetAllAsync(x => x.BranchId == id, includeProperties: "Branch");
            return Json(new { data = classList });
        }
        #endregion
    }
}

using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class WhyUsSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public WhyUsSectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Upsert()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "whyussection", navItem = "contentManagement" };

            var Id = 1;
            WhyUsSection WhyUsSection = await _unitOfWork.WhyUsSection.GetFirstOrDefaultAsync(x => x.Id == Id);

            if (WhyUsSection is null)
                return View();
            else
                return View(WhyUsSection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(WhyUsSection obj)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "whyussection", navItem = "contentManagement" };

            await _unitOfWork.WhyUsSection.Update(obj);
            TempData["success"] = "Why Us Section Details updated successfully.";
            await _unitOfWork.SaveAsync();

            return View(obj);
        }
    }
}

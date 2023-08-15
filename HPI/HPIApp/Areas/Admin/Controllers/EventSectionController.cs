using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class EventSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventSectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Upsert()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "eventSection", navItem = "contentManagement" };

            var id = 1;
            EventsSection EventsSection = await _unitOfWork.EventSection.GetFirstOrDefaultAsync(x => x.Id == id);

            if (EventsSection is null)
                return View();
            else
                return View(EventsSection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EventsSection obj)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "eventSection", navItem = "contentManagement" };

            await _unitOfWork.EventSection.Update(obj);
            TempData["success"] = "Event Section Details updated successfully.";
            await _unitOfWork.SaveAsync();

            return View(obj);
        }
    }
}

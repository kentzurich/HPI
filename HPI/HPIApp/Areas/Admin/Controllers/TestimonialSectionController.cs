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
    public class TestimonialSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestimonialSectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "testimonialSection", navItem = "contentManagement" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimony([FromBody] int id)
        {
            var testimony = await _unitOfWork.TestimonialSection.GetFirstOrDefaultAsync(x => x.Id == id);

            if(testimony is null) return Json(new { success = false, message = "Error while adding/removing testimony." });

            if (testimony.isAdded.Equals(true)) 
                testimony.isAdded = false;
            else 
                testimony.isAdded = true;

            await _unitOfWork.TestimonialSection.Update(testimony);
            await _unitOfWork.SaveAsync();

            return Json(new { success = true, message = "Operation successful." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var obj = await _unitOfWork.TestimonialSection.GetFirstOrDefaultAsync(x => x.Id == id);

                if (obj is null) return Json(new { error = false, message = "Error while deleting." });

                await _unitOfWork.TestimonialSection.Remove(obj);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true, message = "Testimonial deleted successfully." });
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
            var testimonialSections = await _unitOfWork.TestimonialSection.GetAllAsync(includeProperties: "ApplicationUser");
            return Json(new { data = testimonialSections });
        }
        [HttpGet]
        public async Task<IActionResult> ViewTestimony(int id)
        {
            var getTestimonial = await _unitOfWork.TestimonialSection.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "ApplicationUser");
            return Json(new { data = getTestimonial });
        }
        #endregion
    }
}

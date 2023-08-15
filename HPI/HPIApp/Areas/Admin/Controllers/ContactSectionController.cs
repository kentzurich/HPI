using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public ContactSectionController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "contactSection", navItem = "contentManagement" };
            return View();
        }

        public async Task<IActionResult> ViewMessage(int? id)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "contactSection", navItem = "contentManagement" };
            ContactSection ContactSection = await _unitOfWork.ContactSection.GetFirstOrDefaultAsync(x => x.Id == id);
            return View(ContactSection);
        }

        public async Task<IActionResult> SendMessage(ContactSection ContactSection)
        {
            await _emailSender.SendEmailAsync(ContactSection.Email, $"RE: {ContactSection.Subject}", ContactSection.Reply);
            TempData["success"] = "Message successfully sent.";
            return RedirectToAction(nameof(Index));
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contactSectionList = await _unitOfWork.ContactSection.GetAllAsync();
            return Json(new { data = contactSectionList });
        }
        #endregion
    }
}

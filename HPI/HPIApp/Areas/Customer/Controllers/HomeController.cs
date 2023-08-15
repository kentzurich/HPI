using HPIApp.Areas.Identity.Pages.Account;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Models.ViewModel;
using HPIApp.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HPIApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            if(User.IsInRole(StaticDetails.ROLE_CUSTOMER))
            {
                return LocalRedirect("~/Customer/Dashboard");
            }
            else if(User.IsInRole(StaticDetails.ROLE_ADMIN))
            {
                return LocalRedirect("~/Admin/Dashboard");
            }
            else
            {
                CustomerIndexVM CustomerIndexVM = new()
                {
                    companyDetails = await _unitOfWork.CompanyDetails.GetFirstOrDefaultAsync(x => x.Id == 1),
                    heroSection = await _unitOfWork.HeroSection.GetFirstOrDefaultAsync(x => x.Id == 1),
                    whyUsSection = await _unitOfWork.WhyUsSection.GetFirstOrDefaultAsync(x => x.Id == 1),
                    aboutUsSection = await _unitOfWork.AboutUsSection.GetFirstOrDefaultAsync(x => x.Id == 1),
                    eventsSection = await _unitOfWork.EventSection.GetFirstOrDefaultAsync(x => x.Id == 1),
                    faqSection = await _unitOfWork.FAQSection.GetAllAsync(),
                    testimonialSection = await _unitOfWork.TestimonialSection.GetAllAsync(x => x.isAdded == true, includeProperties: "ApplicationUser"),
                    gallerySection = await _unitOfWork.GallerySection.GetAllAsync()
                };

                return View(CustomerIndexVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertContact(CustomerIndexVM CustomerIndexVM)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ContactSection.AddAsync(CustomerIndexVM.contactSection);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Your message has been sent. Thank you!";
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
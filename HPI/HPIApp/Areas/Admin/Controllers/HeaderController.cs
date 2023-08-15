using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class HeaderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HeaderController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> UpsertLogo()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "logo", navItem = "contentManagement" };
            
            var id = 1;
            Logo logo = await _unitOfWork.Logo.GetFirstOrDefaultAsync(x => x.Id == id);

            if (logo is null)
                return View();
            else
                return View(logo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpsertLogo(Logo obj, IFormFile? imgLogoFile)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "logo", navItem = "contentManagement" };

            if(imgLogoFile is not null)
                CustomImageValidation(imgLogoFile, "logoUrl");

            if(!ModelState.IsValid)
                return View(obj);

            var logoId = 1;
            var logoUrlFromDb = _unitOfWork.Logo.GetFirstOrDefaultAsync(x => x.Id == logoId).GetAwaiter().GetResult().logoUrl;

            if (imgLogoFile is not null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"img\logo");
                var extension = Path.GetExtension(imgLogoFile.FileName);

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                if (logoUrlFromDb is not null) // if image is exists in db
                {
                    var oldImagePath = Path.Combine(wwwRootPath, logoUrlFromDb.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath)) System.IO.File.Delete(oldImagePath);
                }
                
                using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                {
                    imgLogoFile.CopyTo(fileStreams);
                }

                obj.logoUrl = @"\img\logo\" + filename + extension;
            }
            else 
                obj.logoUrl = logoUrlFromDb;

            await _unitOfWork.Logo.Update(obj);
            TempData["success"] = "Logo updated successfully.";
            await _unitOfWork.SaveAsync();

            return View(obj);
        }

        public async Task<IActionResult> UpsertCompanyDetails()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "companyDetails", navItem = "contentManagement" };
            
            var id = 1;
            CompanyDetails CompanyDetails = await _unitOfWork.CompanyDetails.GetFirstOrDefaultAsync(x => x.Id == id);

            if (CompanyDetails is null)
                return View();
            else
                return View(CompanyDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpsertCompanyDetails(CompanyDetails obj)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "companyDetails", navItem = "contentManagement" };

            await _unitOfWork.CompanyDetails.Update(obj);
            TempData["success"] = "Company Details updated successfully.";
            await _unitOfWork.SaveAsync();

            return View(obj);
        }

        public async Task<IActionResult> UpsertHeroSection()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "heroSection", navItem = "contentManagement" };
            
            var id = 1;
            HeroSection HeroSection = await _unitOfWork.HeroSection.GetFirstOrDefaultAsync(x => x.Id == id);

            if (HeroSection is null)
                return View();
            else
                return View(HeroSection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpsertHeroSection(HeroSection obj, IFormFile? imgFile)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "heroSection", navItem = "contentManagement" };

            if (imgFile is not null)
                CustomImageValidation(imgFile, "backgroundImgUrl");

            if(!ModelState.IsValid)
                return View(obj);

            var heroSectionId = 1;
            var imgFromDb = _unitOfWork.HeroSection.GetFirstOrDefaultAsync(x => x.Id == heroSectionId).GetAwaiter().GetResult().backgroundImgUrl;

            if (imgFile is not null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"img\herosection");
                var extension = Path.GetExtension(imgFile.FileName);

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                if (imgFromDb is not null) // if image is exists in db
                {
                    var oldImagePath = Path.Combine(wwwRootPath, imgFromDb.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath)) System.IO.File.Delete(oldImagePath);
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                {
                    imgFile.CopyTo(fileStreams);
                }

                obj.backgroundImgUrl = @"\img\herosection\" + filename + extension;
            }
            else
                obj.backgroundImgUrl = imgFromDb;

            await _unitOfWork.HeroSection.Update(obj);
            TempData["success"] = "Hero Section Details updated successfully.";
            await _unitOfWork.SaveAsync();

            return View(obj);
        }

        private void CustomImageValidation(IFormFile PhotoUrl, string propertyName)
        {
            var errorMessage = string.Empty;
            var supportedTypes = new[] { "jpg", "jpeg", "png" };
            var fileExt = Path.GetExtension(PhotoUrl.FileName).Substring(1);

            if (!supportedTypes.Contains(fileExt))
                ModelState.AddModelError(propertyName, $"File extension of {propertyName} is invalid - Only Upload jpg/jpeg/png/ image file.");
            //else if (PhotoUrl.Length > 1024)
            //    ModelState.AddModelError(propertyName, $"File size of {propertyName} shoule be up to 1024KB");
        }
    }
}

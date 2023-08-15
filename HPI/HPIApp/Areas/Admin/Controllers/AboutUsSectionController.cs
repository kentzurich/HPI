using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class AboutUsSectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AboutUsSectionController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Upsert()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "aboutUsSection", navItem = "contentManagement" };

            var id = 1;
            AboutUsSection AboutUsSection = await _unitOfWork.AboutUsSection.GetFirstOrDefaultAsync(x => x.Id == id);

            if (AboutUsSection is null)
                return View();
            else
                return View(AboutUsSection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AboutUsSection obj, IFormFile? imgFile)
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "aboutUsSection", navItem = "contentManagement" };

            if (imgFile is not null)
                CustomImageValidation(imgFile, "VideoBoxUrl");

            if (!ModelState.IsValid)
                return View(obj);

            var Id = 1;
            var videoBoxUrl = _unitOfWork.AboutUsSection.GetFirstOrDefaultAsync(x => x.Id == Id).GetAwaiter().GetResult().VideoBoxUrl;

            if (imgFile is not null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"img\aboutus");
                var extension = Path.GetExtension(imgFile.FileName);

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                if (videoBoxUrl is not null) // if image is exists in db
                {
                    var oldImagePath = Path.Combine(wwwRootPath, videoBoxUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                {
                    imgFile.CopyTo(fileStreams);
                }

                obj.VideoBoxUrl = @"\img\aboutus\" + filename + extension;
            }
            else
                obj.VideoBoxUrl = videoBoxUrl;

            await _unitOfWork.AboutUsSection.Update(obj);
            TempData["success"] = "About Us Section Details updated successfully.";
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

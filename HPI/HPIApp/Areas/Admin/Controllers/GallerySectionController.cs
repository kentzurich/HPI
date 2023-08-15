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
    public class GallerySectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GallerySectionController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "gallerySection", navItem = "contentManagement" };
            IEnumerable<GallerySection> GallerySection = await _unitOfWork.GallerySection.GetAllAsync();
            return View(GallerySection);
        }

        public IActionResult Create()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "gallerySection", navItem = "contentManagement" };
            return View(new GallerySection());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<GallerySection> obj, List<IFormFile> imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile is not null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    foreach (IFormFile file in imgFile)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var galleryPath = @"img\gallery\";
                        var finalPath = Path.Combine(wwwRootPath, galleryPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStreams = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))
                        {
                            file.CopyTo(fileStreams);
                        }

                        obj.Add(
                            new GallerySection()
                            {
                                ImgUrl = $"\\{galleryPath}\\{filename}"
                            });
                    }
                    await _unitOfWork.GallerySection.AddRangeAsync(obj);
                    await _unitOfWork.SaveAsync();
                }

                TempData["success"] = "Gallery added successfully.";
                return RedirectToAction(nameof(Index));
            }
            else 
                return View(obj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await _unitOfWork.GallerySection.GetFirstOrDefaultAsync(x => x.Id == id);
            if (image is not null)
            {
                var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, image.ImgUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath)) System.IO.File.Delete(oldImagePath);

                await _unitOfWork.GallerySection.Remove(image);
                await _unitOfWork.SaveAsync();
            }
            return Json(new { success = true, message = "Image deleted successfully." });
        }
    }
}

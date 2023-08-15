using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HPIApp.ViewComponents
{
    public class UserPhotoViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserPhotoViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claim = _unitOfWork.ApplicationUser.GetUserClaims((ClaimsIdentity)User.Identity).GetAwaiter().GetResult().Value;
            ApplicationUser applicationUser = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == claim);
            return View(applicationUser);
        }
    }
}

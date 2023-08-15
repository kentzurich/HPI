using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(IUnitOfWork unitOfWork,
                              UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult ManageUser()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "manageRole", navItem = "userManagement" };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LockUnlockAcc([FromBody] string id)
        {
            var objFromDb = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id.Equals(id));
            if (objFromDb is null)
                return Json(new { success = false, message = "Error while locking/unlocking." });

            if (objFromDb.LockoutEnd is not null)
                objFromDb.LockoutEnd = null;
            else
                objFromDb.LockoutEnd = Convert.ToDateTime(DateTime.Now.AddYears(1000).ToString("MM/dd/yyyy"));

            await _unitOfWork.ApplicationUser.Update(objFromDb);
            await _unitOfWork.SaveAsync();

            return Json(new { success = true, message = "Operation successful." });
        }

        public IActionResult AdminUserList()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "createAdminUser", navItem = "userManagement" };
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claim = _unitOfWork.ApplicationUser.GetUserClaims((ClaimsIdentity)User.Identity).GetAwaiter().GetResult().Value;
            var userList = await _unitOfWork.ApplicationUser.GetAllAsync(x => x.Id != claim);
            var allUserList = _unitOfWork.ApplicationUser.FilterUserRoles(userList, _userManager);

            return Json(new { data = allUserList });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdmin()
        {
            var claim = _unitOfWork.ApplicationUser.GetUserClaims((ClaimsIdentity)User.Identity).GetAwaiter().GetResult().Value;
            var userList = await _unitOfWork.ApplicationUser.GetAllAsync(x => x.Id != claim);
            var adminUserList = _unitOfWork.ApplicationUser.FilterUserRoles(userList, _userManager, StaticDetails.ROLE_ADMIN);

            return Json(new { data = adminUserList });
        }
    }
}

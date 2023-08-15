using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HPIApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["_AdminSidebar"] = new _AdminSidebar { view = "dashboard", navItem = "dashboard" };
            return View();
        }
    }
}

using HPIApp.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HPIApp.Models;
using HPIApp.Utility;

namespace HPIApp.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _db;

        public DbInitializer(
           UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
           ApplicationDBContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                    _db.Database.Migrate();
                    
            }
            catch (Exception ex) { }

            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(StaticDetails.ROLE_ADMIN).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_ADMIN)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_CUSTOMER)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Adm1nUs3r",
                    FirstName = "Admin",
                    LastName = "User",
                    Birthdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy")),
                    MobileNo = "1234",
                    PresentAddress = "Sta Palomaria",
                    City = "Nueva Ecija",
                    Country = "Philippines",
                    MemberPhotoUrl = "\\img\\admin\\Profile.png",
                    GenderId = 1,
                    ReligionId = 1,
                    ClassId = 1,
                    RegistrationDate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"))
                }, "Adm1n_1").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(x => x.UserName == "Adm1nUs3r");
                //set created user to admin role
                _userManager.AddToRoleAsync(user, StaticDetails.ROLE_ADMIN).GetAwaiter().GetResult();
            }
            return;
        }
    }
}

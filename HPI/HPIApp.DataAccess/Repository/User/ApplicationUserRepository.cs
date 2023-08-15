using HPIApp.DataAccess.Data;
using HPIApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

namespace HPIApp.DataAccess.Repository.User
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDBContext _db;
        public ApplicationUserRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(ApplicationUser obj)
        {
            _db.Update(obj);
        }

        public async Task<Claim> GetUserClaims(ClaimsIdentity claimsIdentity)
        {
            return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        }

        public IEnumerable<ApplicationUser> FilterUserRoles(IEnumerable<ApplicationUser> userList, UserManager<IdentityUser> _userManager, string role = null)
        {
            foreach (var user in userList)
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

            if (role is not null)
                userList = userList.Where(x => x.Role == role);

            return userList.ToList();
        }
    }
}

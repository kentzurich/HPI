using HPIApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System.Security.Claims;

namespace HPIApp.DataAccess.Repository.User
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser> 
    {
        Task Update(ApplicationUser obj);
        Task<Claim> GetUserClaims(ClaimsIdentity claimsIdentity);
        IEnumerable<ApplicationUser> FilterUserRoles(IEnumerable<ApplicationUser> userList, UserManager<IdentityUser> _userManager, string role = null);
    }
}

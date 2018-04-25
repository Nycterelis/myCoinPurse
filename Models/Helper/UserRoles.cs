using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myCoinPurse.Models.Helper
{
    public class UserRoles
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        public bool AddUserToRole(string UserId, string Role)
        {
            try
            {
                var result = userManager.AddToRole(UserId, Role);
                return result.Succeeded;
            }
            catch
            {
                return false;
            }
        }
    }
}
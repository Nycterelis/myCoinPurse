using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace myCoinPurse.Models.Helper
{
    public static class ExtensionMethods
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static int? GetHouseholdId(this IIdentity user)
        {
            var claimsUser = (ClaimsIdentity)user;
            var HouseholdClaim = claimsUser.Claims.FirstOrDefault(c => c.Type == "HouseholdId");
            if (HouseholdClaim != null)
            {
                return int.Parse(HouseholdClaim.Value);
            }
            else
            {
                return null;
            }
        }

        public static bool IsInHousehold(this IIdentity user)
        {
            var claimsUser = (ClaimsIdentity)user;
            var hId = claimsUser.Claims.FirstOrDefault(c => c.Type == "HouseholdId");
            return (hId != null && !string.IsNullOrWhiteSpace(hId.Value));
        }
        public static string GetFullName(this IIdentity user)
        {
            var claimsUser = (ClaimsIdentity)user;
            var claim = claimsUser.Claims.FirstOrDefault(c => c.Type == "Name");
            if (claim != null)
            {
                return claim.Value;
            }
            else
            {
                return null;
            }
        }
        public static async Task RefreshAuthentication(this HttpContextBase context, ApplicationUser user)
        {
            context.GetOwinContext().Authentication.SignOut();
            await context.GetOwinContext().Get<ApplicationSignInManager>()
                .SignInAsync(user, isPersistent: false, rememberBrowser: false);
        }
    }
}
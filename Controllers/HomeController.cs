using Microsoft.AspNet.Identity;
using myCoinPurse.Models;
using myCoinPurse.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myCoinPurse.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AuthorizeHouseholdRequired]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var myHousehold = db.Households.Select(h => h.Members == user);
            var myHh = db.Users.Find(userId).Household;
            var hhAccounts = myHh.Accounts.ToList();
            //var hhTransactions = myHh.Accounts.SelectMany()
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize]
        //public ActionResult CreateJoinHousehold(Guid? code)
        //{
        //    //If the current user accessing this page already has a HouseholdId, send them to their dashboard
        //    if (User.Identity.IsInHousehold())
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    HouseHoldViewModel vm = new HouseHoldViewModel();

        //    //Determine whether the user has been sent an invite and set property values 
        //    if (code != null)
        //    {
        //        string msg = "";
        //        if (ValidInvite(code, ref msg))
        //        {
        //            Invite result = db.Invites.FirstOrDefault(i => i.HHToken == code);

        //            vm.IsJoinHouse = true;
        //            vm.HHId = result.HouseholdId;
        //            vm.HHName = result.Household.Name;

        //            //Set USED flag to true for this invite

        //            result.HasBeenUsed = true;

        //            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
        //            user.InviteEmail = result.Email;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            return RedirectToAction("InviteError", new { errMsg = msg });
        //        }
        //    }
        //    return View(vm);
        //}
        //private bool ValidInvite(Guid? code, ref string message)
        //{

        //    if ((DateTime.Now - db.Invites.FirstOrDefault(i => i.HHToken == code).InviteDate).TotalDays < 6)
        //    {
        //        bool result = db.Invites.FirstOrDefault(i => i.HHToken == code).HasBeenUsed;
        //        if (result)
        //        {
        //            message = "invalid";
        //        }
        //        else
        //        {
        //            message = "valid";
        //        }

        //        return !result;
        //    }
        //    else
        //    {
        //        message = "expired";
        //        return false;
        //    }

        //}
    }
}
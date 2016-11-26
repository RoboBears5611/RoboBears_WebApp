using Microsoft.AspNet.Identity.Owin;
using RoboBears.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoboBears.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find(string ReturnAction)
        {
            ViewBag.ReturnAction = ReturnAction;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Find")]
        public ActionResult FindRequest(FindRequest fr, string ReturnAction)
        {
            var UserIdTask = UserManager.FindByNameAsync(fr.Username);

            return RedirectToAction(ReturnAction, new { UserId = UserIdTask.Result.Id });
        }

        public ActionResult Grant(string UserId)
        {
            if (UserId == null)
                return RedirectToAction("Find", new { ReturnAction = "Grant" });
            Debug.WriteLine("Grant Page for:"+UserId);

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibbitMVC.ViewModel;

namespace RibbitMVC.Controllers
{
    public class HomeController : RibbitControllerBase
    {
        //lots of things in common, so add base controller
        public HomeController(): base(){}

        public ActionResult Index()
        {
            // CurrentUser
            // Security
            if (!Security.IsAuthenticated)
            {
                return View("Landing", new LoginSignupViewModel());
            }
            var timeline = Ribbits.GetTimelineFor(Security.UserId).ToArray();
            return View("Timeline", timeline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            throw new NotImplementedException(username + "followed");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unfollow(string username)
        {
            throw new NotImplementedException(username + "unfollowed");
        }

        //all registed users list
        public ActionResult Profiles()
        {
            throw new NotImplementedException();
        }

        public ActionResult Followers()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            var user = Users.GetAllFor(Security.UserId);
            return View("Buddies", new BuddiesViewModel()
            {
                User = user,
                Buddies = user.Followers
            });
        }

        public ActionResult Following()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            var user = Users.GetAllFor(Security.UserId);
            return View("Buddies", new BuddiesViewModel()
            {
                User = user,
                Buddies = user.Followings
            });
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView("_CreateRibbitPartial",
                new CreateRibbitViewModel());
        }
        //why [ChildActionOnly]
        [HttpPost]
        [ChildActionOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRibbitViewModel model)
        {
            if (ModelState.IsValid)
            {
                Ribbits.Create(Security.UserId, model.Status);
                Response.Redirect("/");
            }
            return PartialView("_CreateRibbitPartial", model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibbitMVC.Data;
using RibbitMVC.Models;
using RibbitMVC.Services;

namespace RibbitMVC.Controllers
{
    public class RibbitControllerBase : Controller
    {
        //protected
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IRibbitService Ribbits { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }
        public IUserProfileService Profiles { get; private set; }
        
        public RibbitControllerBase()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Ribbits = new RibbitService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
            Profiles = new UserProfileService(DataContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GoToReferrer()
        {
            if (Request.UrlReferrer != null)
            {
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

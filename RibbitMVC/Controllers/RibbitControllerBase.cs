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
        public IRibbitService Ribbits { get; set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }

        public RibbitControllerBase()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Ribbits = new RibbitService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

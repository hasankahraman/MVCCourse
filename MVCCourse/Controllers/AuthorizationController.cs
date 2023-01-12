using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        UserManager userManager = new UserManager(new EFUserDAL());
        public ActionResult Index()
        {
            var users = userManager.GetList();
            return View(users);
        }
    }
}
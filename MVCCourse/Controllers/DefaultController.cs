using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        ContentManager contentManager = new ContentManager(new EFContentDAL());
        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }
        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
    }
}
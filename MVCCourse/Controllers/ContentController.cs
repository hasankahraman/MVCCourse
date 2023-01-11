using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EFContentDAL());
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContentsByHeading(int id)
        {
            var contents = contentManager.GetListByHeadingId(id);
            return View(contents);
        }

        public ActionResult GetAllContent()
        {
            var allContent = contentManager.GetList();
            return View(allContent);
        }
        [HttpPost]
        public ActionResult GetAllContent(string search)
        {
            var allContent = contentManager.GetList(search);
            return View(allContent);
        }
    }
}
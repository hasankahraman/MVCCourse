using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EFContentDAL());
        public ActionResult MyContents()
        {
            var contents = contentManager.GetListByWriter();
            return View(contents);
        }
    }
}
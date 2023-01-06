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
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult MyContents()
        {
            int id;
            var sessionInfo = (string)Session["Email"];
            id = writerManager.GetWriterIdBySession(sessionInfo);

            var contents = contentManager.GetListByWriter(id);
            return View(contents);
        }
    }
}
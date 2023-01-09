using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCCourse.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        ContentManager contentManager = new ContentManager(new EFContentDAL());
        public ActionResult WriterProfile()
        {
            var sessionInfo = (string)Session["Email"];
            int writerID = writerManager.GetWriterIdBySession(sessionInfo);

            var writer = writerManager.GetById(writerID);
            return View(writer);
        }

        public ActionResult MyHeadings()
        {
            var sessionInfo = (string)Session["Email"];
            int writerID = writerManager.GetWriterIdBySession(sessionInfo);
            var myHeadings = headingManager.GetListByWriter(writerID);
            return View(myHeadings);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> categories = (from x in categoryManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            var sessionInfo = (string)Session["Email"];
            int writerID = writerManager.GetWriterIdBySession(sessionInfo);
            heading.WriterId = writerID;
            heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.Status = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categories = (from x in categoryManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            var heading = headingManager.GetById(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            var sessionInfo = (string)Session["Email"];
            int writerID = writerManager.GetWriterIdBySession(sessionInfo);
            heading.CreatedAt = DateTime.Now;
            heading.WriterId = writerID;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetById(id);
            heading.Status = false;
            headingManager.HeadingDelete(heading);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult AllHeadings(int p = 1)
        {

            var headings = headingManager.GetList().ToPagedList(p, 4);
            return View(headings);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            var sessionInfo = (string)Session["Email"];
            int writerID = writerManager.GetWriterIdBySession(sessionInfo);
            content.WriterId = writerID;
            content.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.Status = true;
            //content.HeadingId = 1;
            contentManager.ContentAdd(content);
            return RedirectToAction("Headings", "Default");
        }
    }
}
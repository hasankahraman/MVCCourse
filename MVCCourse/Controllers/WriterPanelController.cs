using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult WriterProfile()
        {
            return View();
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
    }
}
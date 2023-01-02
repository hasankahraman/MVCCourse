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
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeadings()
        {
            var myHeadings = headingManager.GetListByWriter();
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
            heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 1;
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
            heading.CreatedAt = DateTime.Now;
            heading.WriterId = 1;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeadings");
        }
    }
}
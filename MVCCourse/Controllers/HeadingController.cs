using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult Index()
        {
            var headings = headingManager.GetList();
            return View(headings);
        }
        public ActionResult HeadingReport()
        {
            var headings = headingManager.GetList();
            return View(headings);
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

            List<SelectListItem> writer = (from x in writerManager.List()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();
            ViewBag.Writer = writer;

            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categories = (from x in categoryManager.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;

            List<SelectListItem> writer = (from x in writerManager.List()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.Writers = writer;

            var heading = headingManager.GetById(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            heading.CreatedAt = DateTime.Now;
            heading.WriterId = heading.WriterId;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetById(id);
            heading.Status = false;
            headingManager.HeadingDelete(heading);
            return RedirectToAction("Index");
        }
    }
}
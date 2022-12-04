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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());
        public ActionResult Index()
        {
            var abouts = aboutManager.GetList();
            return View(abouts);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            about.Status = true;
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteAbout(int id)
        {
            var aboutToDelete = aboutManager.GetById(id);
            return View(aboutToDelete);
        }
        [HttpPost]
        public ActionResult DeleteAbout(About about)
        {
            about.Status = false;
            aboutManager.AboutUpdate(about);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var aboutToUpdate = aboutManager.GetById(id);
            return View(aboutToUpdate);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.AboutUpdate(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AddAboutOnPartialView()
        {
            return PartialView();
        }

    }
}
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager manager = new ImageFileManager(new EFImageFileDAL());
        public ActionResult Index()
        {
            var images = manager.GetList();
            return View(images);
        }
    }
}
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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public ActionResult Index()
        {
            var writers = writerManager.List();
            return View(writers);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            return View();
        }
    }
}
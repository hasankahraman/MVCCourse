using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        WriterValidator validator = new WriterValidator();
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
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writer = writerManager.GetById(id);
            return View(writer);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {

            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
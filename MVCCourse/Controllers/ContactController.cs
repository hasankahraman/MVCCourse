using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EFContactDAL());
        ContactValidator validator = new ContactValidator();
        public ActionResult Index()
        {
            var contacts = contactManager.GetList();
            return View(contacts);
        }
        //[HttpGet]
        public ActionResult GetContactMessageDetails(int id)
        {
            var contact = contactManager.GetById(id);
            return View(contact);
        }
    }
}
using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        //MessageValidator validator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messages = messageManager.GetListInbox();
            return View(messages);
        }
        public ActionResult Sentbox()
        {
            var messages = messageManager.GetListSentbox();
            return View(messages);
        }
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            return RedirectToAction("Inbox");
        }
        public ActionResult GetMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            return View(message);
        }
    }
}
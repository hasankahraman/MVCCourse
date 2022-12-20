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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator validator = new MessageValidator();
        [Authorize]
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
            message.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.SenderMail = "admin@admin.com";

            ValidationResult result = validator.Validate(message);
            if (result.IsValid)
            {
                messageManager.MessageAdd(message);

                return RedirectToAction("Sentbox");
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
        public ActionResult GetMessageDetails(int id)
        {
            var message = messageManager.GetById(id);
            message.IsRead = true;
            messageManager.MessageUpdate(message);
            return View(message);
        }
    }
}
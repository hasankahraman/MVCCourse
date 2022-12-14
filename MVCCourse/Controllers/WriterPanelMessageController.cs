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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator validator = new MessageValidator();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            var sessionInfo = (string)Session["Email"];
            var messages = messageManager.GetListInbox(sessionInfo);
            return View(messages);
        }
        public ActionResult Sentbox()
        {
            var sessionInfo = (string)Session["Email"];
            var messages = messageManager.GetListSentbox(sessionInfo);
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
            var sessionInfo = (string)Session["Email"];
            message.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.SenderMail = sessionInfo;

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

        public PartialViewResult MessageListMenu()
        {
            var sessionInfo = (string)Session["Email"];
            ViewBag.MessageInboxCount = messageManager.MessageUnreadCount(sessionInfo);
            ViewBag.MessageSentBoxCount = messageManager.MessageSentboxCount(sessionInfo);
            return PartialView();
        }
    }
}
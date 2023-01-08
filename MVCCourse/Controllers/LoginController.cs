using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCourse.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        UserManager manager = new UserManager(new EFUserDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var isLoginSuccessful = manager.Login(user);
            if (isLoginSuccessful)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                Session["Name"] = user.Name;
                return RedirectToAction("Index","Heading");
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı adı veya şifre hatalı ya da yok.";
                return RedirectToAction("Index"); 
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var isLoginSuccessful = writerManager.Login(writer);
            if (isLoginSuccessful)
            {
                FormsAuthentication.SetAuthCookie(writer.Email, false);
                Session["Email"] = writer.Email;
                return RedirectToAction("MyHeadings", "WriterPanel");
            }
            else
            {
                ViewBag.LoginError = "Kullanıcı adı veya şifre hatalı ya da yok.";
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}
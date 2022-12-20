using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCourse.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        UserManager manager = new UserManager(new EFUserDAL());

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
    }
}
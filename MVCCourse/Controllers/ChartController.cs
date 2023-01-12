using MVCCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<ChartCategory> CategoryList()
        {
            List<ChartCategory> cc = new List<ChartCategory>();
            cc.Add(new ChartCategory() { Name = "Yazılım", Count = 25 });
            cc.Add(new ChartCategory() { Name = "Donanım", Count = 12 });
            cc.Add(new ChartCategory() { Name = "Veritabanı", Count = 40 });
            cc.Add(new ChartCategory() { Name = "Network", Count = 23 });
            cc.Add(new ChartCategory() { Name = "Security", Count = 6 });

            return cc;
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
        
    }
}
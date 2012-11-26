using System;
using System.Web.Mvc;

namespace Samples.BinbinHttpModules.Log4Net.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult NewException(string message)
        {
            throw new Exception(message);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
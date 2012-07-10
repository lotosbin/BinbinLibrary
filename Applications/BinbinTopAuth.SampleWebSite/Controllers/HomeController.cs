using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinbinTopAuth.SampleWebSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            this.ViewBag.TopAuthUrl = BinbinTopAuthentication.GetAuthUrl();
            return View();
        }
        public ActionResult TopLoginSuccess()
        {
            return this.View();
        }
    }
}

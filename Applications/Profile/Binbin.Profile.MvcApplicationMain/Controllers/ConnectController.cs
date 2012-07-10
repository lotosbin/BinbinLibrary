using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binbin.Profile.MvcApplicationMain.Controllers
{
    public class ConnectController : Controller
    {
        //
        // GET: /Connect/

        public ActionResult Index()
        {
            var appkey = "23852038099067549e02dbb743008ebb";
            var url = this.HttpContext.Request.Url;
            //var redirectUri = url.Scheme + "://" + url.Host + ":" + url.Port;
            var redirectUri = "http://www.binbinsoft.com";
            this.ViewBag.KaixinUrl = @"http://api.kaixin001.com/oauth2/authorize?response_type=code&client_id=" + appkey + "&redirect_uri=" + this.Server.UrlEncode(redirectUri) + "&scope=basic&display=popup";
            return View();
        }

    }
}

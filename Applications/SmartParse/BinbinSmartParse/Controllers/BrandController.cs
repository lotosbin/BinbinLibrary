using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinbinSmartParse.Controllers
{
    public class BrandController : BaseController
    {
        //
        // GET: /Brand/
        public ActionResult Name(string url)
        {
            var html = GetWebPageContent(url);
            var brandnames = new List<string>(){
            "6pm","coach"};
            var results = brandnames.AsParallel().Where(b => html.ToLower().Contains(b.ToLower())).ToList();
            return this.Json(new { data = results },JsonRequestBehavior.AllowGet);
        }

    }
}

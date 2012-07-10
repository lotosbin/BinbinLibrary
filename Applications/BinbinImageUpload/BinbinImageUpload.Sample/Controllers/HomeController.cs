using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Binbin.ImageUpload;

namespace BinbinImageUpload.Sample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string s)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {
            try
            {

                HttpPostedFileBase Pic = Request.Files[0];

                string SavedFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(Pic.FileName);
                var errMsg = string.Empty;
                var result = UploadHelper.UploadImage(Pic, "product", SavedFileName, out errMsg);
                if (string.IsNullOrEmpty(result))
                {
                    this.ModelState.AddModelError("error", errMsg);
                }
                else
                {
                    return this.View((object)result);
                }
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("error", ex);
            }
            return View();
        }

    }
}

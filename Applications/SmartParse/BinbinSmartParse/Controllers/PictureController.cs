using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BinbinSmartParse.Controllers
{
    public class BaseController : Controller
    {
        protected string GetWebPageContent(string url)
        {
            WebRequest req = WebRequest.Create(url);
            req.Method = "GET";

            var response = req.GetResponse();

            if (response != null)
            {
                var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                return sr.ReadToEnd();
            }

            return string.Empty;
        }
    }
    public class PictureController : BaseController
    {
        //
        // GET: /Picture/

        public ActionResult Index(string url)
        {
            return Json(new { urls = GetImageUrls(url, 100) },JsonRequestBehavior.AllowGet);
        }
        private string[] GetImageUrls(string url, int baseWidth)
        {
            if (url.StartsWith("http://") == false && url.StartsWith("https://") == false)
                url = string.Concat("http://", url);

            var html = GetWebPageContent(url);

            var matches = Regex.Matches(html, "<img[^>]+>");

            var picUrls = new List<string>();

            var urlHeader = url.Substring(0, url.LastIndexOf("/"));
            if (urlHeader.ToLower() == "http:/" || urlHeader.ToLower() == "https:/")
                urlHeader = url;
            for (var i = 0; i < matches.Count; i++)
            {
                var srcMatch = Regex.Match(matches[i].Value, "src=[\"]?([^\"]+)[\"]?");
                if (!srcMatch.Success)
                    continue;

                var widMatch = Regex.Match(matches[i].Value, "width=[\"]?([\\d]+)[\"]?");

                if (widMatch.Success && int.Parse(widMatch.Groups[1].Value) < 100)
                    continue;

                var path = srcMatch.Groups[1].Value;

                if (path.StartsWith("http://") || path.StartsWith("https://"))
                {
                    picUrls.Add(path);
                }
                else
                {
                    while (path.StartsWith("../"))
                    {
                        path = path.Substring(2);
                        urlHeader = urlHeader.Substring(0, urlHeader.LastIndexOf("/"));
                    }
                    picUrls.Add(string.Concat(urlHeader, urlHeader.EndsWith("/") ? "" : "/", path));
                }
            }

            return picUrls.ToArray();
        }

    }
}

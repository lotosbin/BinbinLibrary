using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace BinbinCdnMvc
{
    public static class ScriptExtensions
    {

        /// <summary>
        /// CDNs the script.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="contentUrl">The content URL.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        /// -------------------------------------------------------------------------------------------------
        ///  Change History:
        ///  Date			Who		            Changes Made
        ///  2010/9/13 14:27                binbin.liu           create
        /// ------------------------------------------------------------------------------------------------- 
        [Obsolete("«Î π”√ public static MvcHtmlString CDNScript(this HtmlHelper html, List<string> urls)", false)]
        public static MvcHtmlString CDNScript(this HtmlHelper html, string contentUrl, string version)
        {
            string realVersion = version;
            var minVersion = Settings.Default.ContentMinVersion;
            if (null != minVersion)
            {
                if (string.Compare(version, minVersion) < 0)
                {
                    realVersion = minVersion;
                }
            }
            var contentLink = new TagBuilder("script");
            var contentServerUrl = Settings.Default.ContentServerUrl;
            string format = contentUrl;
            if (!string.IsNullOrEmpty(contentServerUrl))
            {
                format = (contentUrl).ToLower().Replace("~/scripts/", "/scripts/").Replace("/scripts/", contentServerUrl + "scripts/");
            }
            else
            {
                if (VirtualPathUtility.IsAppRelative(format))
                {
                    format = VirtualPathUtility.ToAbsolute(format);
                }

            }
            if (Settings.Default.UseMinScript)
            {
                if (!format.EndsWith(".min.js", true, CultureInfo.InvariantCulture))
                {
                    format = format.Replace(".js", ".min.js");
                }
            }
            format += "?t=" + realVersion;
            contentLink.MergeAttribute("src", format);
            contentLink.MergeAttribute("type", @"text/javascript");
            return MvcHtmlString.Create(contentLink.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString CDNScript(this HtmlHelper html, List<string> urls)
        {
            return MvcHtmlString.Create(string.Join("", urls.ConvertAll(u => CDNScript(html, u, "2011062401"))));
        }
    }
}
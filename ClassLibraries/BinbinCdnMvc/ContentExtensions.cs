using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using System.Web;

namespace BinbinCdnMvc
{
    public static class ContentExtensions
    {
        /// <summary>
        /// CDNs the CSS.
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
        [Obsolete("«Î π”√public static MvcHtmlString CDNCss(this HtmlHelper html, List<string> urls)", false)]
        public static MvcHtmlString CDNCss(this HtmlHelper html, string contentUrl, string version)
        {
            string realVersion = version;
            var minVersion = Settings.Default.ContentMinVersion;
            if (null != minVersion)
            {
                if (String.Compare(version, minVersion) < 0)
                {
                    realVersion = minVersion;
                }
            }
            var contentLink = new TagBuilder("link");
            var contentServerUrl = Settings.Default.ContentServerUrl;
            string format = contentUrl;
            if (!String.IsNullOrEmpty(contentServerUrl))
            {
                format = (contentUrl ).ToLower().Replace("~/content/", "/content/").Replace("/content/", contentServerUrl + "content/");
            }
            else
            {
                if (VirtualPathUtility.IsAppRelative(format))
                {
                    format = VirtualPathUtility.ToAbsolute(format);
                }
            }
            if (Settings.Default.UseMinCss)
            {
                if (!format.EndsWith(".min.css", true, CultureInfo.InvariantCulture))
                {
                    format = format.Replace(".css", ".min.css");
                }
            }
            format += "?t=" + realVersion;
            contentLink.MergeAttribute("href", format);
            contentLink.MergeAttribute("type", @"text/css");
            contentLink.MergeAttribute("rel", @"stylesheet");
            return MvcHtmlString.Create(contentLink.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString CDNCss(this HtmlHelper html, List<string> urls)
        {
            return MvcHtmlString.Create(string.Join("", urls.ConvertAll(u => CDNCss(html, u, "2011062401").ToHtmlString())));
        }

    }
}
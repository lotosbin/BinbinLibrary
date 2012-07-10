using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Binbin.System
{
    /// <summary>
    /// 去除HTML标记
    /// </summary>
    public static class StringTrimHtmlHelper
    {
        /// <summary>
        ///   //去除HTML标记
        /// </summary>
        /// <param name="htmlstring"> The htmlstring. </param>
        /// <returns> </returns>
        /// -------------------------------------------------------------------------------------------------
        /// Change History:
        /// Date			Who		            Changes Made
        /// 2010/5/31 17:39                binbin.liu           create
        /// -------------------------------------------------------------------------------------------------
        [Obsolete("Use TrimHtml")]
        public static string NoHtml(string htmlstring)
        {
            return TrimHtml(htmlstring);
        }

        /// <summary>
        ///   //去除HTML标记
        /// </summary>
        /// <param name="htmlstring"> The htmlstring. </param>
        /// <returns> </returns>
        public static string TrimHtml(string htmlstring)
        {
            if (String.IsNullOrEmpty(htmlstring))
            {
                return String.Empty;
            }
            //删除脚本
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"<", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @">", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"\r\n", "", RegexOptions.IgnoreCase);
            htmlstring = HttpUtility.HtmlEncode(htmlstring).Trim();
            return htmlstring;
        }
    }
}
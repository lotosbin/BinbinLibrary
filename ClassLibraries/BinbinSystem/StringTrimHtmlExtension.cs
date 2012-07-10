using System;
using System.Web;

namespace Binbin.System
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringTrimHtmlExtension
    {
        /// <summary>
        ///   ȥ��html���
        /// </summary>
        /// <param name="html"> </param>
        /// <returns> </returns>
        [Obsolete("use TrimHtml")]
        public static string NoHtml(this string html)
        {
            return StringTrimHtmlHelper.TrimHtml(html);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static int NoHtmlTextLength(this string html)
        {
            var s = HttpUtility.HtmlDecode(StringTrimHtmlHelper.TrimHtml(html));

            return s.Length;
        }

        /// <summary>
        ///   ȥ��html���
        /// </summary>
        /// <param name="text"> </param>
        /// <returns> </returns>
        public static string TrimHtml(this string text)
        {
            return StringTrimHtmlHelper.TrimHtml(text);
        }
    }
}
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Binbin.CommonService
{
    /// <summary>
    /// 
    /// </summary>
    /// -------------------------------------------------------------------------------------------------
    ///  Change History:
    ///  Date			Who		            Changes Made
    /// ------------------------------------------------------------------------------------------------- 
    public static class StringExtension
    {
        public static string ToHtmlNewLine(this string text)
        {
            return text.Replace("\r\n", "<br />");
        }
        /// <summary>
        /// 当条件为真时，放回指定字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="condition"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string ConditionReplace(this string source, bool condition, string target)
        {
            if (condition)
            {

                return target;
            }
            return source;
        }
        public static string AddHttp(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            var lower = s.ToLower();
            if (lower.StartsWith("http://")
                || lower.StartsWith("https://"))
            {
                return s;
            }
            return "http://" + s;
        }
        /// <summary>
        /// //去除HTML标记
        /// </summary>
        /// <param name="htmlstring">The htmlstring.</param>
        /// <returns></returns>
        /// -------------------------------------------------------------------------------------------------
        ///  Change History:
        ///  Date			Who		            Changes Made
        ///  2010/5/31 17:39                binbin.liu           create
        /// ------------------------------------------------------------------------------------------------- 
        public static string NoHtml(string htmlstring)
        {
            if (string.IsNullOrEmpty(htmlstring))
            {
                return string.Empty;
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

        public static int NoHtmlTextLength(this string html)
        {
            var s = System.Web.HttpUtility.HtmlDecode(NoHtml(html));

            return s.Length;
        }

        #region Truncate

        /// <summary>
        /// 按字符截断
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="s">The s.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// -------------------------------------------------------------------------------------------------
        ///  Change History:
        ///  Date			Who		            Changes Made
        ///  2010/6/21 11:25                binbin.liu           create
        /// ------------------------------------------------------------------------------------------------- 
        public static string Truncate(this HtmlHelper htmlHelper, string s, int length)
        {
            return StringTruncate.Truncate(s, length);
        }
        /// <summary>
        /// 按字符截断
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Truncate(this string text, int length)
        {
            return StringTruncate.Truncate(text, length);
        }
        /// <summary>
        /// 判断字符串是否需要截断
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="s">The s.</param>
        /// <param name="length">The length.</param>
        /// <returns>
        /// 	<c>true</c> if the specified HTML helper is truncated; otherwise, <c>false</c>.
        /// </returns>
        /// -------------------------------------------------------------------------------------------------
        ///  Change History:
        ///  Date			Who		            Changes Made
        ///  2010/6/21 11:27                binbin.liu           create
        /// ------------------------------------------------------------------------------------------------- 
        public static bool IsTruncated(this HtmlHelper htmlHelper, string s, int length)
        {
            return StringTruncate.IsTruncated(s, length);
        }
        /// <summary>
        /// 判断字符串是否需要截断
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsTruncated(this string text, int length)
        {
            return StringTruncate.IsTruncated(text, length);
        }

        #endregion
        public static string GetPartStr(this string s,int l,string endStr)
        {
            return getPartStr(s, l, endStr);
        }
        public static string getPartStr(string s, int l, string endStr)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            byte[] encodedBytes = System.Text.Encoding.ASCII.GetBytes(s);
            string outPut = "";

            for (int i = 0; i < encodedBytes.Length; i++)
            {
                outPut += s.Substring(i, 1);
                if ((int)encodedBytes[i] == 63)  //是中文
                {
                    l -= 2;
                }
                else
                {
                    l -= 1;
                }
                if (l <= 0)
                    break;
            }
            endStr = l <= 0 ? endStr : "";
            return outPut + endStr;


            //string temp = s.Substring(0, (s.Length < l + 1) ? s.Length : l + 1);
            //byte[] encodedBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(temp);

            //string outputStr = "";
            //int count = 0;

            //for (int i = 0; i < temp.Length; i++)
            //{
            //    if ((int)encodedBytes[i] == 63)
            //        count += 2;
            //    else
            //        count += 1;
            //    if (count <= l - endStr.Length)
            //        outputStr += temp.Substring(i, 1);
            //    else if (count > l)
            //        break;
            //}

            //if (count <= l)
            //{
            //    outputStr = temp;
            //    endStr = "";
            //}

            //outputStr += endStr;

            //return outputStr;
        }
    }
}

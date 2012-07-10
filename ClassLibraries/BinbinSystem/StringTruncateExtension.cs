using System.Web.Mvc;

namespace Binbin.System
{
    /// <summary>
    /// ×Ö·û´®½Ø¶ÏÀàÀ©Õ¹
    /// </summary>
    public static class StringTruncateExtension
    {
        /// <summary>
        ///   ÅÐ¶Ï×Ö·û´®ÊÇ·ñÐèÒª½Ø¶Ï
        /// </summary>
        /// <param name="htmlHelper"> The HTML helper. </param>
        /// <param name="s"> The s. </param>
        /// <param name="length"> The length. </param>
        /// <returns> <c>true</c> if the specified HTML helper is truncated; otherwise, <c>false</c> . </returns>
        /// -------------------------------------------------------------------------------------------------
        /// Change History:
        /// Date			Who		            Changes Made
        /// 2010/6/21 11:27                binbin.liu           create
        /// -------------------------------------------------------------------------------------------------
        public static bool IsTruncated(this HtmlHelper htmlHelper, string s, int length)
        {
            return StringTruncate.IsTruncated(s, length);
        }

        /// <summary>
        ///   ÅÐ¶Ï×Ö·û´®ÊÇ·ñÐèÒª½Ø¶Ï
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="length"> </param>
        /// <returns> </returns>
        public static bool IsTruncated(this string text, int length)
        {
            return StringTruncate.IsTruncated(text, length);
        }

        /// <summary>
        ///   °´×Ö·û½Ø¶Ï
        /// </summary>
        /// <param name="htmlHelper"> The HTML helper. </param>
        /// <param name="s"> The s. </param>
        /// <param name="length"> The length. </param>
        /// <returns> </returns>
        /// -------------------------------------------------------------------------------------------------
        /// Change History:
        /// Date			Who		            Changes Made
        /// 2010/6/21 11:25                binbin.liu           create
        /// -------------------------------------------------------------------------------------------------
        public static string Truncate(this HtmlHelper htmlHelper, string s, int length)
        {
            return StringTruncate.Truncate(s, length);
        }

        /// <summary>
        ///   °´×Ö·û½Ø¶Ï
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="length"> </param>
        /// <returns> </returns>
        public static string Truncate(this string text, int length)
        {
            return StringTruncate.Truncate(text, length);
        }
    }
}
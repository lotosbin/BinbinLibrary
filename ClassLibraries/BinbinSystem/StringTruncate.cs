using System;
using System.Text.RegularExpressions;

namespace Binbin.System
{
    /// <summary>
    /// ×Ö·û´®½Ø¶Ï¸¨ÖúÀà
    /// </summary>
    public static class StringTruncate
    {
        /// <summary>
        ///   Ó¢ÎÄ×Ö·û³¤¶ÈÎª1£¬ÖÐÎÄ×Ö·û³¤¶ÈÎª2
        /// </summary>
        /// <param name="str"> </param>
        /// <returns> </returns>
        public static int GetStringLength(string str)
        {
            str = Regex.Replace(str, "[^-x00-xff ~!@#$%&*()_+|\\={};:\'\"/?.,<>]", "aa");
            return str.Length;
        }

        /// <summary>
        ///   ÅÐ¶Ï×Ö·û´®ÊÇ·ñÐèÒª½Ø¶Ï
        /// </summary>
        /// <param name="s"> The s. </param>
        /// <param name="length"> The length. </param>
        /// <returns> <c>true</c> if the specified s is truncated; otherwise, <c>false</c> . </returns>
        /// -------------------------------------------------------------------------------------------------
        /// Change History:
        /// Date			Who		            Changes Made
        /// 2010/6/21 11:28                binbin.liu           create
        /// -------------------------------------------------------------------------------------------------
        public static bool IsTruncated(string s, int length)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            return s.Length > length;
        }

        /// <summary>
        ///   ½Ø¶Ï×Ö·û´®
        /// </summary>
        /// <param name="s"> The s. </param>
        /// <param name="length"> The length. </param>
        /// <returns> </returns>
        /// -------------------------------------------------------------------------------------------------
        /// Change History:
        /// Date			Who		            Changes Made
        /// 2010/5/11 14:51                binbin.liu           create
        /// -------------------------------------------------------------------------------------------------
        public static string Truncate(string s, int length)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.Empty;
            }
            string truncated;
            if (s.Length > length &&
                length > 3)
            {
                truncated = s.Substring(0, length - 3) + "...";
            }
            else
            {
                truncated = s;
            }
            return truncated;
        }
    }
}
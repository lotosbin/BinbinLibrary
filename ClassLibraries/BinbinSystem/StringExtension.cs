using System.Collections.Generic;

namespace Binbin.System
{
    /// <summary>
    /// </summary>
    /// -------------------------------------------------------------------------------------------------
    /// Change History:
    /// Date			Who		            Changes Made
    /// -------------------------------------------------------------------------------------------------
    public static class StringExtension
    {
        /// <summary>
        ///   前端添加 Http:// (如果没有)
        /// </summary>
        /// <param name="s"> </param>
        /// <returns> </returns>
        public static string AddHttp(this string s)
        {
            var lower = s.Trim().ToLower();
            if (string.IsNullOrEmpty(lower))
            {
                return s;
            }
            if (lower.StartsWith("http://") ||
                lower.StartsWith("https://"))
            {
                return s;
            }
            return "http://" + s;
        }

        /// <summary>
        ///   条件追加
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="append"> </param>
        /// <param name="use"> </param>
        /// <returns> </returns>
        public static string AppendIf(this string text, string append, bool use)
        {
            return use ? text + append : text;
        }

        /// <summary>
        ///   当条件为真时，放回指定字符串
        /// </summary>
        /// <param name="source"> </param>
        /// <param name="condition"> </param>
        /// <param name="target"> </param>
        /// <returns> </returns>
        public static string ConditionReplace(this string source, bool condition, string target)
        {
            if (condition)
            {
                return target;
            }
            return source;
        }

        /// <summary>
        /// </summary>
        /// <param name="s"> </param>
        /// <param name="l"> </param>
        /// <param name="endStr"> </param>
        /// <returns> </returns>
        public static string GetPartStr(this string s, int l, string endStr)
        {
            return StringHelper.getPartStr(s, l, endStr);
        }

        /// <summary>
        ///   String.Join 的扩展方法
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="seperator"> </param>
        /// <returns> </returns>
        public static string JoinWith(this IEnumerable<string> text, string seperator)
        {
            return string.Join(seperator, text);
        }

        /// <summary>
        ///   条件 切换
        /// </summary>
        /// <param name="text"> </param>
        /// <param name="switchtext"> </param>
        /// <param name="use"> </param>
        /// <returns> </returns>
        public static string SwitchIf(this string text, string switchtext, bool use)
        {
            if (use)
            {
                return switchtext;
            }
            else
            {
                return text;
            }
        }

        /// <summary>
        ///   转全角(SBC case)
        /// </summary>
        /// <param name="text"> 任意字符串 </param>
        /// <returns> 全角字符串 </returns>
        public static string ToFullWidthCharacters(this string text)
        {
            return StringHelper.ToFullWidthCharacters(text);
        }

        /// <summary>
        ///   转半角
        /// </summary>
        /// <param name="text"> </param>
        /// <returns> 半角字符串 </returns>
        public static string ToHalfWidthCharacters(this string text)
        {
            return StringHelper.ToHalfWidthCharacters(text);
        }
    }
}
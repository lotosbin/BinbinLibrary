namespace Binbin.System
{
    /// <summary>
    /// 字符串部分转换成 Html 的扩展
    /// </summary>
    public static class StringConvertHtmlExtension
    {
        /// <summary>
        /// \r\n ==> &lt;br /&gt;
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToHtmlNewLine(this string text)
        {
            return text.Replace("\r\n", "<br />");
        }
    }
}
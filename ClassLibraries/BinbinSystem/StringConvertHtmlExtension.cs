namespace Binbin.System
{
    /// <summary>
    /// �ַ�������ת���� Html ����չ
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
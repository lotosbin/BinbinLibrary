using System.Collections.Generic;

namespace Binbin.System
{
    /// <summary>
    /// 在字符串中分析 Html 标记
    /// </summary>
    public static class StringParseHtmlExtension
    {
        /// <summary>
        /// 取得第一个图片链接
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetImageUrl(this string content)
        {
            return StringParseHtmlHelper.GetImageUrl(content);
        }

        /// <summary>
        ///   取得HTML中所有图片的 URL。
        /// </summary>
        /// <param name="sHtmlText"> HTML代码 </param>
        /// <returns> 图片的URL列表 </returns>
        public static List<string> ParseHtmlImgSrc(this string sHtmlText)
        {
            return StringParseHtmlHelper.ParseHtmlImgSrc(sHtmlText);
        }
    }
}
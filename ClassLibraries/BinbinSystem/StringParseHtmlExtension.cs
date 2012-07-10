using System.Collections.Generic;

namespace Binbin.System
{
    /// <summary>
    /// ���ַ����з��� Html ���
    /// </summary>
    public static class StringParseHtmlExtension
    {
        /// <summary>
        /// ȡ�õ�һ��ͼƬ����
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetImageUrl(this string content)
        {
            return StringParseHtmlHelper.GetImageUrl(content);
        }

        /// <summary>
        ///   ȡ��HTML������ͼƬ�� URL��
        /// </summary>
        /// <param name="sHtmlText"> HTML���� </param>
        /// <returns> ͼƬ��URL�б� </returns>
        public static List<string> ParseHtmlImgSrc(this string sHtmlText)
        {
            return StringParseHtmlHelper.ParseHtmlImgSrc(sHtmlText);
        }
    }
}
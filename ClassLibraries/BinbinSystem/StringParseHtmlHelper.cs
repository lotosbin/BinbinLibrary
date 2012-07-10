using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Binbin.System
{
    /// <summary>
    /// ���ַ������� Html ��ǩ�ĸ�����
    /// </summary>
    public static class StringParseHtmlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetImageUrl(string content)
        {
            string url = null;
            string parttern = "<img[^>]*src=\"(?<ref_value>[^\"]*)(?=\")";

            Match match = Regex.Match(content, parttern);
            if (match.Success)
            {
                url = match.Groups["ref_value"].ToString();
            }

            return url;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static List<string> ParseHtmlImgSrc(string sHtmlText)
        {
            // ����������ʽ����ƥ�� img ��ǩ
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            // ����ƥ����ַ���
            MatchCollection matches = regImg.Matches(sHtmlText);
            return (from Match match in matches select match.Groups["imgUrl"].Value).ToList();
        }
    }
}
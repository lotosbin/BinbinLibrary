using System;
using System.Text;

namespace Binbin.System
{
    /// <summary>
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        ///   ×ªÈ«½Ç 
        /// </summary>
        /// <param name="input"> ÈÎÒâ×Ö·û´® </param>
        /// <returns> È«½Ç×Ö·û´® </returns>
        public static string ToFullWidthCharacters(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///   ×ª°ë½Ç
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> °ë½Ç×Ö·û´® </returns>
        public static string ToHalfWidthCharacters(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 &&
                    c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// </summary>
        /// <param name="s"> </param>
        /// <param name="l"> </param>
        /// <param name="endStr"> </param>
        /// <returns> </returns>
        public static string getPartStr(string s, int l, string endStr)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            byte[] encodedBytes = Encoding.ASCII.GetBytes(s);
            string outPut = "";

            for (int i = 0; i < encodedBytes.Length; i++)
            {
                outPut += s.Substring(i, 1);
                if ((int)encodedBytes[i] == 63) //ÊÇÖÐÎÄ
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
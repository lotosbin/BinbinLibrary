using System;
using System.Text.RegularExpressions;

namespace Binbin.System
{
    /// <summary>
    /// �ַ�����֤����
    /// </summary>
    public static class StringValidate
    {
        /// <summary>
        /// �ж��Ƿ��������ַ�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasChineseLetter(string input)
        {
            bool result = false;
            int chfrom = Convert.ToInt32("4e00", 16);
            int chend = Convert.ToInt32("9fff", 16);
            for (int i = 0; i < input.Length; i++)
            {
                int code = Char.ConvertToUtf32(input, i);
                if (code >= chfrom ||
                    code <= chend)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// �ж��Ƿ��������ַ�
        /// </summary>
        /// <param name="input"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool IsChineseLetter(string input, int index)
        {
            int code = 0;
            int chfrom = Convert.ToInt32("4e00", 16);
            int chend = Convert.ToInt32("9fff", 16);
            if (input != "")
            {
                code = Char.ConvertToUtf32(input, index);
                return code >= chfrom && code <= chend;
            }
            return false;
        }
        /// <summary>
        /// �ж��Ƿ��������ʽ
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        public static bool IsCorrectEmail(string strString)
        {
            return Regex.IsMatch(strString, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        ///   �жϵ�������
        /// </summary>
        /// <param name="email"> </param>
        /// <returns> </returns>
        public static bool IsEmail(string email)
        {
            if (email == null) return false;
            return Regex.IsMatch(email, ".+\\@.+\\..+");
        }

        /// <summary>
        ///   �ж��ַ����Ƿ����ֻ���
        /// </summary>
        /// <param name="phoneNumber"> </param>
        /// <returns> </returns>
        public static bool IsMPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(1[3,5,8][0-9])\d{8}$");
        }
    }
}
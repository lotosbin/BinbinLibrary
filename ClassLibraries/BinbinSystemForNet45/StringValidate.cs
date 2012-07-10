using System;
using System.Text.RegularExpressions;

namespace Binbin.CommonService
{
    public static class StringValidate
    {
        /// <summary>
        /// �ж��ַ����Ƿ����ֻ���
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsMPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(1[3,5,8][0-9])\d{8}$");
        }
        

        /// <summary>
        /// �жϵ�������
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            if (email == null) return false;
            return Regex.IsMatch(email, ".+\\@.+\\..+");
        }
    }
}
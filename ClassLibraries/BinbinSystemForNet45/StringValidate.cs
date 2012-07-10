using System;
using System.Text.RegularExpressions;

namespace Binbin.CommonService
{
    public static class StringValidate
    {
        /// <summary>
        /// 判断字符串是否是手机号
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsMPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"(1[3,5,8][0-9])\d{8}$");
        }
        

        /// <summary>
        /// 判断电子邮箱
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
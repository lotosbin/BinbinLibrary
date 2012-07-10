namespace Binbin.System
{
    /// <summary>
    /// 字符串验证扩展类
    /// </summary>
    public static class StringValidateExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmail(this string text)
        {
            return StringValidate.IsEmail(text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsHasChineseLetter(this string input)
        {
            return StringValidate.HasChineseLetter(input);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsMPhoneNumber(this string phoneNumber)
        {
            return StringValidate.IsMPhoneNumber(phoneNumber);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNotEmail(this string text)
        {
            return !StringValidate.IsEmail(text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotHasChineseLetter(this string input)
        {
            return !StringValidate.HasChineseLetter(input);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsNotMPhoneNumber(this string phoneNumber)
        {
            return !StringValidate.IsMPhoneNumber(phoneNumber);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNotNullAndNotEmpty(this string text)
        {
            return !string.IsNullOrEmpty(text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
    }
}
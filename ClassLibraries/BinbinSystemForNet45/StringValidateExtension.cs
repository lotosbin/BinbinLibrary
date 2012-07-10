namespace Binbin.CommonService
{
    public static class StringValidateExtension
    {
        public static bool IsEmail(this string text)
        {
            return StringValidate.IsEmail(text);
        }
        public static bool IsNotEmail(this string text)
        {
            return !StringValidate.IsEmail(text);
        }
        public static bool IsMPhoneNumber(this string phoneNumber)
        {
            return StringValidate.IsMPhoneNumber(phoneNumber);
        }
        public static bool IsNotMPhoneNumber(this string phoneNumber)
        {
            return !StringValidate.IsMPhoneNumber(phoneNumber);
        }
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        public static bool IsNotNullAndNotEmpty(this string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
}
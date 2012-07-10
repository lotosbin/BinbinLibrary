namespace Binbin.System
{
    public static class StringConvertIntExtension
    {
        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

    }
}
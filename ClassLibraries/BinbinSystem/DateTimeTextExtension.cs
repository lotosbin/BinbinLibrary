using System;

namespace Binbin.System
{
    /// <summary>
    /// ʱ����ʾ��������
    /// </summary>
    public static class DateTimeTextExtension
    {
        /// <summary>
        /// n����ǰ,nСʱǰ,n��ǰ,n����ǰ
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToTextFromNow(this DateTime time)
        {
            return DateTimeText.ToTextFromNow(time);
        }
    }
}
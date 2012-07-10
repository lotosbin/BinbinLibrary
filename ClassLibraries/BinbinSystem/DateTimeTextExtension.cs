using System;

namespace Binbin.System
{
    /// <summary>
    /// 时间显示辅助方法
    /// </summary>
    public static class DateTimeTextExtension
    {
        /// <summary>
        /// n分钟前,n小时前,n天前,n星期前
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToTextFromNow(this DateTime time)
        {
            return DateTimeText.ToTextFromNow(time);
        }
    }
}
using System;

namespace Binbin.System
{
    /// <summary>
    /// 时间显示辅助方法
    /// </summary>
    public static class DateTimeText
    {
        /// <summary>
        /// n分钟前,n小时前,n天前,n星期前
        /// </summary>
        /// <param name="postTime"></param>
        /// <returns></returns>
        public static string ToTextFromNow(DateTime postTime)
        {
            if (postTime < DateTime.Now)
            {
                return ToTextBeforeNow(postTime);
            }
            else
            {
                return ToTextAfterNow(postTime);
            }
        }

        private static string ToTextBeforeNow(DateTime postTime)
        {
            TimeSpan timeSpan = (DateTime.Now - postTime);

            if (timeSpan.TotalHours < 1)
            {
                return (Math.Floor(timeSpan.TotalMinutes)) + "分钟前";
            }
            if (timeSpan.TotalDays < 1)
            {
                return (Math.Floor(timeSpan.TotalHours)) + "小时前";
            }
            if (timeSpan.TotalDays < 2)
            {
                return "昨天";
            }
            if (timeSpan.TotalDays < 3)
            {
                return "前天";
            }
            if (timeSpan.TotalDays < 7)
            {
                return (Math.Floor(timeSpan.TotalDays)) + "天前";
            }
            if (timeSpan.TotalDays < 30)
            {
                return (Math.Floor(timeSpan.TotalDays)) + "天前";
            }
            return "更久以前";
        }
        private static string ToTextAfterNow(DateTime postTime)
        {
            TimeSpan timeSpan = (postTime - DateTime.Now);

            if (timeSpan.TotalHours < 1)
            {
                return (Math.Floor(timeSpan.TotalMinutes)) + "分钟后";
            }
            if (timeSpan.TotalDays < 1)
            {
                return (Math.Floor(timeSpan.TotalHours)) + "小时后";
            }
            if (timeSpan.TotalDays < 2)
            {
                return "明天";
            }
            if (timeSpan.TotalDays < 3)
            {
                return "后天";
            }
            if (timeSpan.TotalDays < 7)
            {
                return (Math.Floor(timeSpan.TotalDays)) + "天后";
            }
            if (timeSpan.TotalDays < 30)
            {
                return (Math.Floor(timeSpan.TotalDays)) + "天后";
            }
            return "更久以后";
        }
    }
}
using System;

namespace Binbin.System
{
    /// <summary>
    /// math ��������
    /// </summary>
    public static class Math2
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="payAmount"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static bool DeltaEquals(decimal amount, decimal payAmount, decimal delta)
        {
            return Math.Abs(amount - payAmount) < Math.Abs(delta);
        }
    }
}
namespace Binbin.System
{
    /// <summary>
    /// Math 扩展
    /// </summary>
    public static class MathExtension
    {
        /// <summary>
        /// 近似相等于
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static bool IsDeltaEqualTo(this decimal first, decimal second, decimal delta)
        {
            return Math2.DeltaEquals(first, second, delta);
        }
    }
}
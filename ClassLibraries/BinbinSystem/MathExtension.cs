namespace Binbin.System
{
    /// <summary>
    /// Math ��չ
    /// </summary>
    public static class MathExtension
    {
        /// <summary>
        /// ���������
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
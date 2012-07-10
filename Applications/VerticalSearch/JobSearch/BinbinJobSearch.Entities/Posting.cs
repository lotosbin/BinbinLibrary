namespace BinbinJobSearch.Entities
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Posting
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        public int PostingID { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }

        public int MerchantID { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}
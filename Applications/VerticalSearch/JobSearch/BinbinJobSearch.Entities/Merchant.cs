using System;

namespace BinbinJobSearch.Entities
{
    /// <summary>
    /// 商家
    /// </summary>
    public class Merchant
    {
        public int MerchantID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所有者用户名称
        /// </summary>
        public string OwnerUserName { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 职位索引地址
        /// </summary>
        public string PostingFeedUrl { get; set; }
    }
}
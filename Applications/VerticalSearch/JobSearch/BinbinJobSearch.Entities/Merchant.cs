using System;

namespace BinbinJobSearch.Entities
{
    /// <summary>
    /// �̼�
    /// </summary>
    public class Merchant
    {
        public int MerchantID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �������û�����
        /// </summary>
        public string OwnerUserName { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// ְλ������ַ
        /// </summary>
        public string PostingFeedUrl { get; set; }
    }
}
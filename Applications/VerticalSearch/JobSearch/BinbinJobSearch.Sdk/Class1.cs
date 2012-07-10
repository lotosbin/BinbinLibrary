using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinbinJobSearch.Sdk
{
    [Serializable]
    public class PostingFeed
    {
        public string MerchantUserName { get; set; }
        public string MerchantName { get; set; }

        public DateTime UpdateTime { get; set; }
        public List<PostingFeedItem> Items { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinbinJobFeed.Entities
{
    public class Posting
    {
        public int PostingID { get; set; }
        public string MerchantUserName { get; set; }
        public string MerchantName { get; set; }
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}

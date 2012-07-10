using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models.UnreadCount
{
    [Serializable]
    [DataContract]
    public class UnreadCountJson
    {
        public UnreadCountJson()
        {
            this.UnreadCounts = new List<UnreadCountItemJson>();
        }

        [DataMember(Name = "max")]
        public int Max { get; set; }

        [DataMember(Name = "unreadcounts")]
        public List<UnreadCountItemJson> UnreadCounts { get; set; }
    }
}
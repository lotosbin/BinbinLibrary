using System;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models.UnreadCount
{
    [Serializable]
    [DataContract]
    public class UnreadCountItemJson
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "newestItemTimestampUsec")]
        public string NewestItemTimestampUsec { get; set; }
    }
}
using System;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class Summary
    {
        [DataMember(Name = "direction")]
        public string Direction { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }
    }
}
using System;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class Origin
    {
        [DataMember(Name = "streamId")]
        public string StreamId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "htmlUrl")]
        public string HtmlUrl { get; set; }
    }
}
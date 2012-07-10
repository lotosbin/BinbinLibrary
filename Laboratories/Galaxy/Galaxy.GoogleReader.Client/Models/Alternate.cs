using System;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class Alternate
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
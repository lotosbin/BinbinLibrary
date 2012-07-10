using System;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class Self
    {
        [DataMember(Name = "fref")]
        public string Href { get; set; }
    }
}
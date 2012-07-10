using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class ListAllJson
    {
        public ListAllJson()
        {
            this.Items = new List<ListAllJsonItem>();
            this.Self = new List<Self>();
        }

        [DataMember(Name = "direction")]
        public string Direction { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "continuation")]
        public string Continuation { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "updated")]
        public string Updated { get; set; }

        [DataMember(Name = "items")]
        public List<ListAllJsonItem> Items { get; set; }

        [DataMember(Name = "self")]
        public List<Self> Self { get; set; }
    }
}
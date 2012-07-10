using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Galaxy.GoogleReader.Client.Models.Tag
{
    [Serializable]
    [DataContract]
    public class TagJson
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "sordid")]
        public string SortId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.Client.Models.Tag
{
    [Serializable]
    [DataContract]
    public class TagsJson
    {
        public TagsJson()
        {
            this.Tags = new List<TagJson>();
        }
        [DataMember(Name = "tags")]
        public List<TagJson> Tags { get; set; }
    }
}
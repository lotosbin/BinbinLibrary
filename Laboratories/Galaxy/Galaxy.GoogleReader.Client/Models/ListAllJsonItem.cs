using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Galaxy.GoogleReader.WpfApplication.Models
{
    [Serializable]
    [DataContract]
    public class ListAllJsonItem
    {
        public ListAllJsonItem()
        {
            this.Categories = new List<string>();
            this.LinkingUsers = new List<LinkingUser>();
            this.Comments = new List<Comment>();
            this.Annotations = new List<Annotation>();
        }

        [DataMember(Name = "crawlTimeMsec")]
        public string CrawlTimeMsec { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "published")]
        public string Published { get; set; }

        [DataMember(Name = "updated")]
        public string Updated { get; set; }

        [DataMember(Name = "categories")]
        public List<string> Categories { get; set; }

        [DataMember(Name = "alternate")]
        public List<Alternate> Alternate { get; set; }

        [DataMember(Name = "summary")]
        public Summary Summary { get; set; }

        [DataMember(Name = "origin")]
        public Origin Origin { get; set; }

        [DataMember(Name = "linkingUsers")]
        public List<LinkingUser> LinkingUsers { get; set; }

        [DataMember(Name = "comments")]
        public List<Comment> Comments { get; set; }

        [DataMember(Name = "annotations")]
        public List<Annotation> Annotations { get; set; }
    }
}
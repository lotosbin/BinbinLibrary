using System;
using System.ComponentModel.DataAnnotations;

namespace BinbinAccount.Entities
{
    public class AspnetUser
    {
        [Key]
        public int UserID { get; set; }

        public Guid ApplicationID { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}
using BinbinAccount.Entities;

namespace BinbinAccount.Services
{
    public class BinbinMembershipUser
    {
        public BinbinMembershipUser()
        {
            
        }
        public BinbinMembershipUser(AspnetUser user)
        {
            this.UserName = user.UserName;
            this.UserID = user.UserID;
        }

        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}
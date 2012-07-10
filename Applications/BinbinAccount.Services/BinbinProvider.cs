using System;
using System.Web.Security;
using BinbinAccount.Entities;

namespace BinbinAccount.Services
{
    public static class BinbinProvider
    {
        public static BinbinMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var user = new AspnetUser()
                           {
                               ApplicationID = Guid.Empty,
                               IsAnonymous = false,
                               LastActivityDate = DateTime.Now,
                               LoweredUserName = username.ToLower(),
                               MobileAlias = string.Empty,
                               UserName = username,
                           };
            var context = new ApplicationServices();
            context.User.Add(user);
            context.SaveChanges();
            status = MembershipCreateStatus.Success;
            return new BinbinMembershipUser(user);
        }

        public static bool ValidateUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
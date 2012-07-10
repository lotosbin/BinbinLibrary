using System;
using System.Runtime.Serialization;
using Galaxy.DynamicControl.Core;
using Galaxy.DynamicControl.Core.Common;

namespace Galaxy.GoogleReader.Client.Models.UserInfo
{
    public class UserInfoJsonEditorProfile : EditorProfile<UserInfoJson>
    {

    }
    public class UserInfoJsonEditorFieldsModel : EditorFieldsModel<UserInfoJson>
    {

    }
    public class UserInfoJsonEditorLayout : EditorLayout<UserInfoJson>
    {

    }
    public class UserInfoJsonEditorActionsModel : EditorActionsModel<UserInfoJson>
    {

    }
    [Serializable]
    [DataContract]
    public class UserInfoJson
    {
        [DataMember(Name = "UserId")]
        public string UserId { get; set; }

        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "userProfileId")]
        public string UserProfileId { get; set; }

        [DataMember(Name = "userEmail")]
        public string UserEmail { get; set; }

        [DataMember(Name = "isBloggerUser")]
        public bool IsBloggerUser { get; set; }

        [DataMember(Name = "signupTimeSec")]
        public int SignupTimeSec { get; set; }
    }
}
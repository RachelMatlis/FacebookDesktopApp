using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.Logic
{
    public class LoggedUser
    {
        private User m_User;
              
        public string UserName { get; private set; }
   
        public string UserBirthday { get; private set; }

        public string UserGender { get; private set; }

        public string UserRelationshipStatus { get; private set; }

        public UserProfile UserProfileInfo { get; private set; }

        public LikedPhotosActionesBase[] GetPhotosAndLikesInfo;
  
        public CheckIn GetCheckInInfo { get; private set; }

        public FBObjectListProxy GetFBObjectList { get; private set; }

        public LoggedUser(User i_LoggedUser)
        {
            m_User = i_LoggedUser;

            UserProfileInfo = new UserProfile(m_User);
            GetCheckInInfo = new CheckIn(m_User);
            GetFBObjectList = new FBObjectListProxy(m_User);

            ////Template Method Collection:
            GetPhotosAndLikesInfo = new LikedPhotosActionesBase[] { new LikedPhotosActionesFirst(m_User), new LikedPhotosActionesChanged(m_User) };

            setUserIntroDetailes();
        }

        private void setUserIntroDetailes()
        {
            UserName = m_User.Name;
            UserGender = m_User.Gender.ToString();

            try
            {
                UserBirthday = m_User.Birthday.ToString();
            }
            catch
            {
                UserBirthday = "No Information";
            }

            try
            {
                UserRelationshipStatus = m_User.RelationshipStatus.ToString();
            }
            catch
            {
                UserRelationshipStatus = "No Information";
            }
        } 
    }
}

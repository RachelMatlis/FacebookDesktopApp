using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using A18_Ex01_Rahel_206082703_Avihay_203766035.Logic;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters.Facebook
{
    public class FBAdapter : FacebookService, ILoginable
    {
        public string m_AppID { private get; set; }

        private User m_loggedInUser;   
        public LoginResult m_LoginResult;

        public bool IsLoginSuccessed { get; private set; }

        public LoggedUser LoggedUserInfo { get; private set; }

        public void Login()
        {
            m_LoginResult = FacebookService.Login(
                m_AppID,
                "public_profile",
                "user_birthday",
                "user_actions.news",
                "user_about_me",
                "user_friends", 
                "publish_actions",
                "user_events", 
                "user_hometown",
                "user_likes",
                "user_location", 
                "user_managed_groups",
                "user_photos", 
                "user_posts", 
                "user_relationships",
                "user_relationship_details", 
                "user_religion_politics",
                "user_tagged_places",
                "read_custom_friendlists");

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_loggedInUser = m_LoginResult.LoggedInUser;
                IsLoginSuccessed = true;
                LoggedUserInfo = new LoggedUser(m_loggedInUser);
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage);
                IsLoginSuccessed = false;
            }
        }
    }
}

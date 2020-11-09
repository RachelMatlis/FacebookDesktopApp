using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using A18_Ex01_Rahel_206082703_Avihay_203766035.Logic;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035
{
    public partial class FacebookProfileForm : Form
    {
        LogIn m_LogIn;
    
        public FacebookProfileForm()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
            m_LogIn = new LogIn();
        }



 

        private void buttonLogin_Click_1(object sender, EventArgs e)
        {
            m_LogIn.loginAndInit();
            if (m_LogIn.IsLoginSuccessed)
            {
                fetchUserInfo();
            }
        }

        private void fetchUserInfo()
        {
            fetchProfileAndCoverPicture();
           fetchIntroUser();
        }
        
        private void fetchProfileAndCoverPicture()
        {
            pictureBoxProfilePicture.Load(m_LogIn.LoggedInUser.PictureLargeURL);
            pictureBoxCoverPicture.LoadAsync(m_LogIn.LoggedInUser.Cover.SourceURL);
        }

        private void fetchIntroUser()
        {
            labelUserName.Text = m_LogIn.LoggedInUser.Name;
            UserBirthdaytextBox.Text = m_LogIn.LoggedInUser.Birthday.ToString();
            UserCitytextBox.Text = m_LogIn.LoggedInUser.Hometown.ToString();
            UserStatustextBox.Text = m_LogIn.LoggedInUser.RelationshipStatus.ToString();
           
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(doAfterlogout);
        }

        private void doAfterlogout()
        {
            this.Hide();
            FacebookProfileForm NewForm = new FacebookProfileForm();
            NewForm.ShowDialog();
            this.Dispose(false); 
        }

        private void buttonPostNewStatus_Click(object sender, EventArgs e)
        {
            m_LogIn.LoggedInUser.PostStatus(textBoxNewStatus.Text);
            MessageBox.Show("Status Posted!"); 
        }

        private void ExitFromApbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelUserRelationshipStatus_Click(object sender, EventArgs e)
        {

        }
    }

}



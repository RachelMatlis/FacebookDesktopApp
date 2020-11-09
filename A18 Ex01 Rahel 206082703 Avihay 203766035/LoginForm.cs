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
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters.Facebook;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035
{
    public partial class LoginForm : Form
    {
        private FBAdapter m_LogIn;
        private string m_ApplicationID;

        public LoginForm()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 300;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
            m_LogIn = LogInSingleton.GetLogInInstance;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (comboBoxAppID.SelectedItem != null)
            {
                logIn();
            }
            else
            {
                MessageBox.Show("Please Select Aplication Id");
            }
        }

        private void logIn()
        {
            m_LogIn.m_AppID = this.m_ApplicationID;
            m_LogIn.Login();

            if (m_LogIn.IsLoginSuccessed)
            {
                FacebookAppForm mainForm = new FacebookAppForm(m_LogIn);
                this.Hide();
                mainForm.Show();
            }
        }

        private void comboBoxAppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxAppID.SelectedIndex)
            {
                case 0:
                    m_ApplicationID = "144345592858458";
                    break;
                case 1:
                    m_ApplicationID = "1450160541956417";
                    break;
            }
        }
    }
}
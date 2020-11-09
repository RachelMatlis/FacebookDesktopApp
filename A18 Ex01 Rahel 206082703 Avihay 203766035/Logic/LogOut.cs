using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035
{
    public class LogOut
    {
        public void LogOutFunc()
        {
            FacebookService.Logout(doAfterlogout);         
        }

        private void doAfterlogout()
        {           
            Form.ActiveForm.Hide();
            LoginForm NewForm = new LoginForm();
            NewForm.ShowDialog();
            Application.Exit();
        }
    }
}
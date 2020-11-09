namespace A18_Ex01_Rahel_206082703_Avihay_203766035
{
    partial class FacebookProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookProfileForm));
            this.pictureBoxCoverPicture = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewStatus = new System.Windows.Forms.TextBox();
            this.groupBoxIntroUser = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserStatustextBox = new System.Windows.Forms.TextBox();
            this.UserCitytextBox = new System.Windows.Forms.TextBox();
            this.UserBirthdaytextBox = new System.Windows.Forms.TextBox();
            this.buttonPostNewStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.groupBoxIntroUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCoverPicture
            // 
            this.pictureBoxCoverPicture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxCoverPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pictureBoxCoverPicture, "pictureBoxCoverPicture");
            this.pictureBoxCoverPicture.Name = "pictureBoxCoverPicture";
            this.pictureBoxCoverPicture.TabStop = false;
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.pictureBoxProfilePicture, "pictureBoxProfilePicture");
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // labelUserName
            // 
            resources.ApplyResources(this.labelUserName, "labelUserName");
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Name = "labelUserName";
            // 
            // buttonLogin
            // 
            resources.ApplyResources(this.buttonLogin, "buttonLogin");
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click_1);
            // 
            // buttonLogout
            // 
            resources.ApplyResources(this.buttonLogout, "buttonLogout");
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxNewStatus
            // 
            resources.ApplyResources(this.textBoxNewStatus, "textBoxNewStatus");
            this.textBoxNewStatus.Name = "textBoxNewStatus";
            // 
            // groupBoxIntroUser
            // 
            this.groupBoxIntroUser.Controls.Add(this.label4);
            this.groupBoxIntroUser.Controls.Add(this.label3);
            this.groupBoxIntroUser.Controls.Add(this.label2);
            this.groupBoxIntroUser.Controls.Add(this.UserStatustextBox);
            this.groupBoxIntroUser.Controls.Add(this.UserCitytextBox);
            this.groupBoxIntroUser.Controls.Add(this.UserBirthdaytextBox);
            resources.ApplyResources(this.groupBoxIntroUser, "groupBoxIntroUser");
            this.groupBoxIntroUser.Name = "groupBoxIntroUser";
            this.groupBoxIntroUser.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // UserStatustextBox
            // 
            resources.ApplyResources(this.UserStatustextBox, "UserStatustextBox");
            this.UserStatustextBox.Name = "UserStatustextBox";
            this.UserStatustextBox.ReadOnly = true;
            // 
            // UserCitytextBox
            // 
            resources.ApplyResources(this.UserCitytextBox, "UserCitytextBox");
            this.UserCitytextBox.Name = "UserCitytextBox";
            this.UserCitytextBox.ReadOnly = true;
            // 
            // UserBirthdaytextBox
            // 
            resources.ApplyResources(this.UserBirthdaytextBox, "UserBirthdaytextBox");
            this.UserBirthdaytextBox.Name = "UserBirthdaytextBox";
            this.UserBirthdaytextBox.ReadOnly = true;
            // 
            // buttonPostNewStatus
            // 
            resources.ApplyResources(this.buttonPostNewStatus, "buttonPostNewStatus");
            this.buttonPostNewStatus.Name = "buttonPostNewStatus";
            this.buttonPostNewStatus.UseVisualStyleBackColor = true;
            // 
            // FacebookProfileForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPostNewStatus);
            this.Controls.Add(this.textBoxNewStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.groupBoxIntroUser);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.pictureBoxCoverPicture);
            this.Name = "FacebookProfileForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.groupBoxIntroUser.ResumeLayout(false);
            this.groupBoxIntroUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCoverPicture;
        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.GroupBox groupBoxIntroUser;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewStatus;
        private System.Windows.Forms.Label labelUserRelationshipStatus;
        public System.Windows.Forms.Label labelUserHometown;
        private System.Windows.Forms.Label labelUserEducation;
        public System.Windows.Forms.Label labelUserBirthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserStatustextBox;
        private System.Windows.Forms.TextBox UserCitytextBox;
        public System.Windows.Forms.TextBox UserBirthdaytextBox;
        private System.Windows.Forms.Button buttonPostNewStatus;
    }
}


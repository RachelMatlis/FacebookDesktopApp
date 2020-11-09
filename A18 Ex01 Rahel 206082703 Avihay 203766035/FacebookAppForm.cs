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
    public partial class FacebookAppForm : Form
    {
        private FBAdapter m_LogIn;
        private LogOut m_LogOut;
        private int m_countButtonDiscoverClicked = 0;

        public FacebookAppForm(FBAdapter i_LoggedUser)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 300;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;

            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }

            m_LogIn = LogInSingleton.GetLogInInstance;
            m_LogIn = i_LoggedUser;
            m_LogOut = new LogOut();

            new Thread(fetchUserInfo).Start();
        }

        private void fetchUserInfo()
        {
            fetchIntroUser();
            fetchProfileAndCoverPicture();
            fetchUserPosts();
            fetchFriends();
            fetchLikedPages();
            fetchEvents();
            fetchFriendsCheckins();       
            loadMainFormdPicsBox();       
        }

        private void loadMainFormdPicsBox()
        {
            try
            {
                if (m_LogIn.LoggedUserInfo.GetFBObjectList.GetFriends().Count != 0)
                {
                    FriendPicturebox.Load(m_LogIn.LoggedUserInfo.GetFBObjectList.GetFriends()[0].PictureNormalURL);
                }
            }
            catch
            {
                FriendPicturebox.Image = FriendPicturebox.ErrorImage;
            }
            
            try
            {
                if (m_LogIn.LoggedUserInfo.GetFBObjectList.GetLikedPages().Count != 0)
                {
                    pictureBoxLikedPages.Load(m_LogIn.LoggedUserInfo.GetFBObjectList.GetLikedPages()[0].PictureNormalURL);
                }
            }
            catch
            {
                pictureBoxLikedPages.Image = pictureBoxLikedPages.ErrorImage;
            }
        }

        /// <summary>
        /// Profile Page:
        /// </summary>
        private void fetchProfileAndCoverPicture()
        {
            pictureBoxProfilePicture.Invoke(new Action(() => pictureBoxProfilePicture.Load(m_LogIn.LoggedUserInfo.UserProfileInfo.GetProfilePictureUrl())));
            pictureBoxProfilePicture.Invoke(new Action(() => pictureBoxCoverPicture.Load(m_LogIn.LoggedUserInfo.UserProfileInfo.GetCoverPictureUrl())));
        }

        private void fetchIntroUser()
        {
            labelUserName.Text = m_LogIn.LoggedUserInfo.UserName;
            labelUserBirthday.Text = m_LogIn.LoggedUserInfo.UserBirthday;
            labelUserGender.Text = m_LogIn.LoggedUserInfo.UserGender;
            labelUserRelationshipStatus.Text = m_LogIn.LoggedUserInfo.UserRelationshipStatus;

            ////labelUserName.Invoke(new Action(() => labelUserName.Text = m_LogIn.LoggedUserInfo.UserName));
            ////labelUserBirthday.Invoke(new Action(() => labelUserBirthday.Text = "Born on: " + m_LogIn.LoggedUserInfo.UserBirthday));
            ////labelUserGender.Invoke(new Action(() => labelUserGender.Text = "Gender: " + m_LogIn.LoggedUserInfo.UserGender));
            ////labelUserRelationshipStatus.Invoke(new Action(() => labelUserRelationshipStatus.Text = m_LogIn.LoggedUserInfo.UserRelationshipStatus));
        }

        private void fetchUserPosts()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.LoadUserPosts(listBoxUserPosts, m_LogIn.LoggedUserInfo.GetFBObjectList.GetPosts());
        }

        private void fetchFriends()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.LoadUserFriends(FriendslistBox, m_LogIn.LoggedUserInfo.GetFBObjectList.GetFriends());
        }

        private void fetchLikedPages()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.LoadLikedPages(listBoxLikedPages, m_LogIn.LoggedUserInfo.GetFBObjectList.GetLikedPages());
        }

        private void fetchEvents()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.LoadEvents(listBoxAllEvents, m_LogIn.LoggedUserInfo.GetFBObjectList.GetEvents());
            m_LogIn.LoggedUserInfo.UserProfileInfo.LoadUpComingEvents(listBoxUpEvents, m_LogIn.LoggedUserInfo.GetFBObjectList.GetUpComingEvents());
        }

        private void listBoxAllEvents_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxAllEvents.SelectedItem != null && m_LogIn.LoggedUserInfo.GetFBObjectList.GetEvents().Count != 0)
            {
                Event selectedEvent = listBoxAllEvents.SelectedItem as Event;
                textBoxDescEvent.Text = selectedEvent.Description;
            }
            else
            {
                textBoxDescEvent.Text = "No Events To Describe";
            }
        }

        private void listBoxUpEvents_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxUpEvents.SelectedItem != null && m_LogIn.LoggedUserInfo.GetFBObjectList.GetUpComingEvents().Count != 0)
            {
                Event selectedEvent = listBoxUpEvents.SelectedItem as Event;
                textBoxDescEvent.Text = selectedEvent.Description;
            }
            else
            {
                textBoxDescEvent.Text = "No Events To Describe";
            }
        }

        private void textBoxDescEvent_Validating(object sender, CancelEventArgs e)
        {
            Event selectedEvent1 = listBoxAllEvents.SelectedItem as Event;
            Event selectedEvent2 = listBoxUpEvents.SelectedItem as Event;
            if (selectedEvent1 != null)
            {
                selectedEvent1.Description = textBoxDescEvent.Text;
            }

            if (selectedEvent2 != null)
            {
                selectedEvent2.Description = textBoxDescEvent.Text;
            }
        }

        private void displaySelectedFriend()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.DisplaySelectedFriend(FriendslistBox, FriendPicturebox);
        }

        private void displaySelectPage()
        {
            m_LogIn.LoggedUserInfo.UserProfileInfo.DisplaySelectPage(listBoxLikedPages, pictureBoxLikedPages);
        }

        private void PostNewStatus()
        {
            if (string.IsNullOrEmpty(textBoxNewStatus.Text))
            {
                MessageBox.Show("Not exist new status to publish");
            }
            else
            {
                m_LogIn.LoggedUserInfo.UserProfileInfo.PostStatus(textBoxNewStatus.Text);
                MessageBox.Show("Status Posted!");
            }

            textBoxNewStatus.Clear();
        }

        private void buttonSelectFriend_Click(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        private void buttonSelectPage_Click(object sender, EventArgs e)
        {
            displaySelectPage();
        }

        private void buttonPostNewStatus_Click(object sender, EventArgs e)
        {
            PostNewStatus();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_LogOut.LogOutFunc();
        }

        /// <summary>
        /// feature 1 page:
        /// </summary>          
        private void fetchFriendsCheckins()
        {
            m_LogIn.LoggedUserInfo.GetCheckInInfo.LoadFriendsCheckIns(listBoxCheckIns);
        }

        private void listBoxCheckIns_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxLocation.Text = listBoxCheckIns.SelectedItem.ToString();
        }

        private void fetchFriendsInlocationEqualCheckin()
        {
            string[] locationInput = textBoxLocation.Text.ToUpper().Split();
            m_LogIn.LoggedUserInfo.GetCheckInInfo.FetchFriendsInlocationEqualCheckin(ListBoxFriendsInLocation, locationInput);
        }
  
        private void loadCheckInInformation()
        {
            User selectedFriend = new User();
            Checkin selectedCheckIn = new Checkin();

            if (ListBoxFriendsInLocation.SelectedItem != null)
            {
                string selectedFriendName = ListBoxFriendsInLocation.SelectedItem.ToString();
                m_LogIn.LoggedUserInfo.GetCheckInInfo.LoadCheckInInformation(selectedFriendName, ref selectedFriend, ref selectedCheckIn);

                fetchCheckInInfo(selectedFriend, selectedCheckIn);
            }
            else
            {
                MessageBox.Show("Please choose location first!");
            }
        }

        private void fetchCheckInInfo(User i_selectedFriendName, Checkin i_selectedCheckIn)
        {
            try
            {
                labelName.Text = "Friend Name: " + i_selectedFriendName.Name;
                labelLocation.Text = "Location: " + i_selectedCheckIn.Place.Name;
                labelDate.Text = "Date and Time: " + i_selectedCheckIn.UpdateTime.ToString();

                if (i_selectedCheckIn.PictureURL != null)
                {
                    pictureBoxCheckinFriendPicture.Load(i_selectedCheckIn.PictureURL);
                }
                else
                {
                    pictureBoxCheckinFriendPicture.Image = pictureBoxCheckinFriendPicture.ErrorImage;
                }
            }
            catch
            {
                labelName.Text = "Friend Name: ";
                labelLocation.Text = "Location: ";
                labelDate.Text = "Date and Time: ";
                pictureBoxCheckinFriendPicture.Image = pictureBoxCheckinFriendPicture.ErrorImage;
                MessageBox.Show("There is no information!");
            }
        }

        private void resetCheckInInfo()
        {
            textBoxLocation.Clear();
            ListBoxFriendsInLocation.Items.Clear();
            labelName.Text = "Friend Name: ";
            labelLocation.Text = "Location: ";
            labelDate.Text = "Date and Time: ";
            pictureBoxCheckinFriendPicture.Image = null;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            resetCheckInInfo();
        }

        private void buttonShowCheckInInformation_Click(object sender, EventArgs e)
        {
            loadCheckInInformation();
        }

        private void buttonSearchLocation_Click(object sender, EventArgs e)
        {   
            fetchFriendsInlocationEqualCheckin();                   
        }

        /// <summary>
        /// feature 2 page:
        /// </summary>
        private void fetchUserMostLikedPictures(bool i_IsFirstFetch)
        {
            int SizeOfDicPicAndLikesByValueOrder = m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[0].SizeOfPhotosAndLikesByValueOrder;
            
            ////Tempale Method subclasses
            int classMethodToActive = 0;

            if (SizeOfDicPicAndLikesByValueOrder >= 3)
            {
                if(!i_IsFirstFetch)
                {
                    classMethodToActive = 1;
                }

                ////Fetch Photos
                m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[classMethodToActive].FetchUserMostLikedPictures(pictureBoxMostLikedPhoto1, pictureBoxMostLikedPhoto2, pictureBoxMostLikedPhoto3);
                
                ////Show Likes
                m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[classMethodToActive].ShowLikes(label1Place, label2Place, label3Place, labelnumber1, labelNumber2, labelNumber3);

                buttonDiscoverMostLikedPhotos.Enabled = false;
                buttonChangeProfilePic.Enabled = true;
                buttonChangePic1.Enabled = true;
                buttonChangePic2.Enabled = true;
                buttonChangePic3.Enabled = true;
                buttonHidePictures.Enabled = true;
            }
            else
            {
                MessageBox.Show("You need to have at least 3 photos on facebook");
            }
        }
       
        private void buttonDiscoverMostLikedPhotos_Click(object sender, EventArgs e)
        {
            m_countButtonDiscoverClicked++;
            bool isDiscoverClickedOnce = true;

            if (m_countButtonDiscoverClicked > 1)
            {
                isDiscoverClickedOnce = false;
            }

            fetchUserMostLikedPictures(isDiscoverClickedOnce);
        }

        private void changeProfilePic()
        {
            bool isProfileChanged = true;

            if (checkBoxPic1.Checked && !checkBoxPic2.Checked && !checkBoxPic3.Checked)
            {
                m_LogIn.LoggedUserInfo.UserProfileInfo.ChangeProfilePic(pictureBoxProfilePicture, pictureBoxMostLikedPhoto1.ImageLocation);
                isProfileChanged = true;
            }
            else if (!checkBoxPic1.Checked && checkBoxPic2.Checked && !checkBoxPic3.Checked)
            {
                m_LogIn.LoggedUserInfo.UserProfileInfo.ChangeProfilePic(pictureBoxProfilePicture, pictureBoxMostLikedPhoto2.ImageLocation);
                isProfileChanged = true;
            }
            else if (!checkBoxPic1.Checked && !checkBoxPic2.Checked && checkBoxPic3.Checked)
            {
                m_LogIn.LoggedUserInfo.UserProfileInfo.ChangeProfilePic(pictureBoxProfilePicture, pictureBoxMostLikedPhoto3.ImageLocation);
                isProfileChanged = true;
            }
            else
            {
                MessageBox.Show("Please select only one picture!");
                isProfileChanged = false;
            }

            if (isProfileChanged)
            {
                MessageBox.Show("Your profile picture has changed!");
            }
        }

        private void hideAllInfoAndSaveit()
        {
            string pic1Url = pictureBoxMostLikedPhoto1.ImageLocation;
            string pic2Url = pictureBoxMostLikedPhoto2.ImageLocation;
            string pic3Url = pictureBoxMostLikedPhoto3.ImageLocation;

            ////Save the photos before the hiding action
            m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[1].SaveCurrPicBoxPicsUrl(pictureBoxMostLikedPhoto1.ImageLocation, pictureBoxMostLikedPhoto2.ImageLocation, pictureBoxMostLikedPhoto3.ImageLocation);

            ////Hide information
            pictureBoxMostLikedPhoto1.Image = null;
            pictureBoxMostLikedPhoto2.Image = null;
            pictureBoxMostLikedPhoto3.Image = null;

            label1Place.Text = "1";
            label2Place.Text = "2";
            label3Place.Text = "3";

            labelnumber1.Text = "1";
            labelNumber2.Text = "2";
            labelNumber3.Text = "3";

            buttonChangePic1.Enabled = false;
            buttonChangePic2.Enabled = false;
            buttonChangePic3.Enabled = false;
            buttonChangeProfilePic.Enabled = false;
            buttonDiscoverMostLikedPhotos.Enabled = true;
        }

        private void buttonHidePictures_Click(object sender, EventArgs e)
        {
            buttonDiscoverMostLikedPhotos.Text = "Restore !";
            buttonHidePictures.Enabled = false;
            hideAllInfoAndSaveit();
        }
        
        private void buttonChangeProfilePic_Click_1(object sender, EventArgs e)
        {
            changeProfilePic();
        }

        private void buttonChangePic1_Click(object sender, EventArgs e)
        {
            m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[0].ChangePicInPicBox1(pictureBoxMostLikedPhoto1, labelnumber1, label1Place);
        }

        private void buttonChangePic2_Click(object sender, EventArgs e)
        {
            m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[0].ChangePicInPicBox2(pictureBoxMostLikedPhoto2, labelNumber2, label2Place);
        }

        private void buttonChangePic3_Click(object sender, EventArgs e)
        {
            m_LogIn.LoggedUserInfo.GetPhotosAndLikesInfo[0].ChangePicInPicBox3(pictureBoxMostLikedPhoto3, labelNumber3, label3Place);
        }
    }
}

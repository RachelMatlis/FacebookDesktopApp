using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.Logic
{
    public class UserProfile
    {
        private User m_User;
        private string m_DisplayMember = "Name";

        public UserProfile(User i_LoggedUser)
        {
            m_User = i_LoggedUser;
        }

        public string GetProfilePictureUrl()
        {
            return m_User.PictureLargeURL;
        }

        public string GetCoverPictureUrl()
        {
            return m_User.Cover.SourceURL;
        }

        public void PostStatus(string i_Status)
        {
            m_User.PostStatus(i_Status);
        }

        public void LoadUserPosts(ListBox i_PostsListBox, List<Post> i_PostsList)
        {
            string DisplayMember = "Message";
            ListBoxApp<Post>.LoadListBox(i_PostsListBox, i_PostsList, DisplayMember);
        }

        public void LoadUserFriends(ListBox i_FriendsListBox, List<User> i_UserFriends)
        {
            ListBoxApp<User>.LoadListBox(i_FriendsListBox, i_UserFriends, m_DisplayMember);
        }

        public void LoadLikedPages(ListBox i_LikedPagesListBox, List<Page> i_LikedPagesList)
        {
            ListBoxApp<Page>.LoadListBox(i_LikedPagesListBox, i_LikedPagesList, m_DisplayMember);
        }

        public void LoadEvents(ListBox i_EventsListBox, List<Event> i_EventsList)
        {
            ListBoxApp<Event>.LoadListBox(i_EventsListBox, i_EventsList, m_DisplayMember);
        }

        public void LoadUpComingEvents(ListBox i_EventsListBox, List<Event> i_UpComingEventsList)
        {
            ListBoxApp<Event>.LoadListBox(i_EventsListBox, i_UpComingEventsList, m_DisplayMember);
        }

        public void DisplaySelectPage(ListBox i_LikedPageslistBox, PictureBox i_LikedPagesPictureBox)
        {
            if(i_LikedPageslistBox.SelectedItems.Count == 1)
            {
                Page selectedPage = i_LikedPageslistBox.SelectedItem as Page;
                if (selectedPage.PictureNormalURL != null)
                {
                    i_LikedPagesPictureBox.Load(selectedPage.PictureNormalURL);
                }
                else
                {
                    i_LikedPagesPictureBox.Image = i_LikedPagesPictureBox.ErrorImage;
                }
            }
        }

        public void DisplaySelectedFriend(ListBox i_ListBoxFriends, PictureBox i_PictureboxFriend)
        {
            if (i_ListBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = i_ListBoxFriends.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    i_PictureboxFriend.Load(selectedFriend.PictureNormalURL);
                }
                else
                {
                    i_PictureboxFriend.Image = i_PictureboxFriend.ErrorImage;
                }
            }
        }

        public void ChangeProfilePic(PictureBox i_ProfilePicBox, string i_PicUrl)
        {
            i_ProfilePicBox.Load(i_PicUrl);
        }
    }
}
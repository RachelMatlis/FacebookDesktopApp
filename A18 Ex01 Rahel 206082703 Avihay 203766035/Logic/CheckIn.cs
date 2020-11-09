using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using Facebook;
using FacebookWrapper.ObjectModel;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.Logic
{
    public class CheckIn
    {
        private User m_User;
        private string m_UserSelectedCheckInToSearch; 

        public CheckIn(User i_LoggedUser)
        {
            m_User = i_LoggedUser;
        }

        public void LoadFriendsCheckIns(ListBox i_FriendsCheckInsListBox)
        {
            i_FriendsCheckInsListBox.Invoke(new Action(() => i_FriendsCheckInsListBox.Items.Clear()));
            i_FriendsCheckInsListBox.Invoke(new Action(() => i_FriendsCheckInsListBox.DisplayMember = "Name"));

            IAggregate FriendsAggregate = new FriendsAggregate(this.m_User);
            IIterator FriendsIterator = FriendsAggregate.CreateIterator();

            if (!FriendsIterator.IsDone)
            {
                foreach (User friend in FriendsIterator.NextItem)
                {
                    foreach (Checkin checkin in friend.Checkins)
                    {
                        if (!i_FriendsCheckInsListBox.Items.Contains(checkin.Place.Name))
                        {
                            i_FriendsCheckInsListBox.Invoke(new Action(() => i_FriendsCheckInsListBox.Items.Add(checkin.Place.Name)));
                        }
                    }

                    if (i_FriendsCheckInsListBox.Items.Count == 0)
                    {
                        i_FriendsCheckInsListBox.Invoke(new Action(() => i_FriendsCheckInsListBox.Items.Add(" There is no friends that have been in this location.")));
                    }
                }
            }
        }

        public void FetchFriendsInlocationEqualCheckin(ListBox i_ListBoxFriendsInLocation, string[] i_LocationInput)
        {
            i_ListBoxFriendsInLocation.Items.Clear();
          
            if (m_User.Friends != null)
            {
                foreach (User friend in m_User.Friends)
                {
                    if (friend.Checkins != null)
                    {
                        foreach (Checkin checkin in friend.Checkins)
                        {
                            if (checkEqualCheckin(i_LocationInput, checkin))
                            {
                                m_UserSelectedCheckInToSearch = checkin.Place.Name;

                                if (!i_ListBoxFriendsInLocation.Items.Contains(checkin.From.Name))
                                {
                                    if(friend.Name == checkin.From.Name)
                                    {
                                        i_ListBoxFriendsInLocation.Items.Add(friend.Name);
                                    }
                                }
                            }
                        }
                    }
                }

                if (i_ListBoxFriendsInLocation.Items.Count == 0)
                {
                    i_ListBoxFriendsInLocation.Items.Add("There is no friends that have been in this location");
                }
            }
        }

        public void LoadCheckInInformation(string i_SelectedFriendName, ref User io_SelectedFriend, ref Checkin io_SelectedCheckIn)
        {
            foreach (User friend in m_User.Friends)
            {
                if (friend.Name == i_SelectedFriendName)
                {
                    foreach (Checkin checkin in friend.Checkins)
                    {
                        if (checkin.Place.Name == m_UserSelectedCheckInToSearch)
                        {
                            io_SelectedFriend = friend;
                            io_SelectedCheckIn = checkin;
                        }
                    }
                }
            }
        }

        private bool checkEqualCheckin(string[] i_Location, Checkin i_Checkin)
        {
            bool isCheckinsEqual = false;

            if (i_Checkin.Place == null || i_Checkin.Place.Name == null)
            {
                isCheckinsEqual = false;
            }
            else
            {
                string[] inputCheckinString = i_Checkin.Place.Name.ToUpper().Split();
                isCheckinsEqual = checkEqual(i_Location, inputCheckinString);
            }

            return isCheckinsEqual;
        }

        private bool checkEqual(string[] i_Strings, string[] i_InputStrings)
        {
            bool isEqual = false;

            foreach (string splittedWord in i_InputStrings)
            {
                foreach (string str in i_Strings)
                {
                    if (str.Equals(splittedWord))
                    {
                        isEqual = true;
                        break;
                    }
                }
            }
   
            return isEqual;
        }
    }
}
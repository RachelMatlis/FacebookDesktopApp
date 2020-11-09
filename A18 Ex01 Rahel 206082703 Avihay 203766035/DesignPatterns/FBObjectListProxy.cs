using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    public class FBObjectListProxy
    {
        private User m_User;

        public FBObjectListProxy(User i_LoggedUser)
        {
            m_User = i_LoggedUser;
        }

        /// <summary>
        /// Return friends list sorted by last name.
        /// </summary>
        /// <returns></returns>
        public List<User> GetFriends()
        {
            return FBObjectListGenerator<User>.GenerateList(() => m_User.Friends).OrderBy(friend => friend.LastName).ToList();
        }

        /// <summary>
        /// Returns from user news feed posts that created by the user only.
        /// </summary>
        /// <returns></returns>
        public List<Post> GetPosts()
        {
            List<Post> userPosts = new List<Post>();

            try
            {
                List<Post> userNewsFeed = FBObjectListGenerator<Post>.GenerateList(() => m_User.NewsFeed);

                foreach (Post post in userNewsFeed)
                {
                    if (post.From.Name == m_User.Name)
                    {
                        userPosts.Add(post);
                    }
                }
            }
            catch
            {
            ////No access to news feed.
            }

            return userPosts;
        }

        public List<Page> GetLikedPages()
        {
            return FBObjectListGenerator<Page>.GenerateList(() => m_User.LikedPages);
        }

        public List<Event> GetEvents()
        {
            return FBObjectListGenerator<Event>.GenerateList(() => m_User.Events);
        }

        public List<Event> GetUpComingEvents()
        {
            List<Event> UpcomingEvents = new List<Event>();

            foreach (Event events in GetEvents())
            {
                if (events.EndTime > DateTime.Now)
                {
                    UpcomingEvents.Add(events);
                }
            }

            return UpcomingEvents;
        }

        /// <summary>
        /// Return user friends checkin's list sorted by the checkin place name.
        /// </summary>
        /// <returns></returns>
        public List<Checkin> GetFriendsCheckins()
        {
            return FBObjectListGenerator<Checkin>.GenerateList(() => m_User.Checkins).OrderBy(checkin => checkin.Place.Name).ToList();
        }
    }
}

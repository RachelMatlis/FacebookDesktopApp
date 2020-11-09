using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using A18_Ex01_Rahel_206082703_Avihay_203766035.Logic;
using FacebookWrapper;
using Facebook;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters.Facebook;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    public class FriendsAggregate : IAggregate
    {
        private User m_User;

        public FriendsAggregate(User i_User)
        {
            this.m_User = i_User;
        }

        public IIterator CreateIterator()
        {
            return new FriendsIterator(m_User.Friends);
        }

        private class FriendsIterator : IIterator
        {
            private FacebookObjectCollection<User> m_Collection;
            private int m_CurrentIdx = 0;
            private int m_Count = -1;

            public object CurrentItem
            {
                get { return m_Collection[m_CurrentIdx]; }
            }

            public bool IsDone
            {
                get { return m_CurrentIdx >= m_Collection.Count; }
            }

            public FriendsIterator(FacebookObjectCollection<User> i_Collection)
            {
                m_Collection = i_Collection;
                m_Count = m_Collection.Count;
            }

            public void Reset()
            {
                m_CurrentIdx = 0;
            }

            public bool Next()
            {
                return ++m_CurrentIdx < m_Collection.Count;
            }

            public IEnumerable<object> NextItem
            {
                get
                {
                    while (!this.IsDone)
                    {
                        yield return CurrentItem;
                        this.Next();
                    }
                }
            }
        }
    }
}

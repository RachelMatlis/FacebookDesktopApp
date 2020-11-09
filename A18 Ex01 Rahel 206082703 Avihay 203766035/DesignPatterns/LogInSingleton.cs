using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns.Adapters.Facebook;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    public class LogInSingleton
    {
        /// <summary>
        /// Static reference to the single instance -> m_LogIn
        /// </summary>
        private static FBAdapter s_LogIn = null;
        private static object lockThis = new object();

        /// <summary>
        /// private CTOR as part as the singltone pattern
        /// </summary>
        private LogInSingleton()
        {
        }

        /// <summary>
        /// Public static accsess point to the single instance of s_LogIn
        /// </summary>
        public static FBAdapter GetLogInInstance
        {
            get
            {
                lock (lockThis)
                {
                    if (s_LogIn == null)
                    {
                        s_LogIn = new FBAdapter();
                    }

                    return s_LogIn;
                }
            }
        }
    }
}
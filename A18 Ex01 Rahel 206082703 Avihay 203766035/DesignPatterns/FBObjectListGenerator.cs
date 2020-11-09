using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    /// <summary>
    /// The 'RealSubject' Class Of Proxy Pattern
    /// </summary>
    public static class FBObjectListGenerator<T>
    {
        private static List<T> m_FBObjectList = null;

        public static List<T> GenerateList(Func<IEnumerable<T>> i_ListGeneratorMethod)
        {
            FBObjectListStrategy<T> strategyList = new FBObjectListStrategy<T> { GenerateListMethod = i_ListGeneratorMethod };

            return strategyList.GenerateList(m_FBObjectList);
        }
    }
}

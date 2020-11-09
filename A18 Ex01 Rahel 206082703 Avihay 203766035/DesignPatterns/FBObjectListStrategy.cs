using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    /// <summary>
    /// Strategy Pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FBObjectListStrategy<T>
    {
        /// using a delegate to a method as the strategy:
        public Func<IEnumerable<T>> GenerateListMethod { get; set; }
        
        public List<T> GenerateList(List<T> i_FBObjectist)
        {     
            if (GenerateListMethod != null)
            {
                i_FBObjectist = GenerateListMethod.Invoke().ToList();
            }

            return i_FBObjectist;
        }
    }
}

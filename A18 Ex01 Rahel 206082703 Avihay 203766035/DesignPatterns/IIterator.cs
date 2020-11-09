using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A18_Ex01_Rahel_206082703_Avihay_203766035.DesignPatterns
{
    public interface IIterator
    {
        bool IsDone { get; }

        object CurrentItem { get; }

        IEnumerable<object> NextItem { get; }

        void Reset();

        bool Next();
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }
}

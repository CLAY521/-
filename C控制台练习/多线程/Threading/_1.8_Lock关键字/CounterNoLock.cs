using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._8_Lock关键字
{
    public class CounterNoLockL:CounterBase
    {
        public int Count { get; private set; }
        public override void Increase()
        {
            Count++;
        }
        public override void Decrease()
        {
            Count--;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    public class CounterNoInterlocked:CounterBase
    {
        public int Count { get; private set; }
        public override void Decrement()
        {
            Count--;
        }
        public override void Increment()
        {
            Count++;
        }
    }
}

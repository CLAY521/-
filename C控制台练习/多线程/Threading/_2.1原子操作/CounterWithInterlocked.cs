using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    public class CounterWithInterlocked:CounterBase
    {
        private int _count;
        public int Count { get { return _count; } }
        public override void Decrement()
        {
            Interlocked.Decrement(ref _count);
        }
        public override void Increment()
        {
            Interlocked.Increment(ref _count);
        }
    }
}

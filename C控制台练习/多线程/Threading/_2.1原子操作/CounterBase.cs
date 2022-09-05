using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    public abstract class CounterBase
    {
        public abstract void Increment();
        public abstract void Decrement();
    }
}

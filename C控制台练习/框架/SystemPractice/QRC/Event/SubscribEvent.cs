using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    /// <summary>
    /// 订阅器类
    /// </summary>
    public class SubscribEvent
    {
        public void Consoles()
        {
            Console.WriteLine("事件存在");
            Console.ReadKey();
        }
    }
}

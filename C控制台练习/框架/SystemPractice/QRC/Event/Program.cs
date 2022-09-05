using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        //声明事件的委托类型
        public delegate void BoilerLogHandler(string status);
        //基于上面的委托定义事件
        public event BoilerLogHandler BoilerEventLog;
        /// <summary>
        /// 触发
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //发布器类（第一次没有触发事件）
            EventTest e = new EventTest();
            //订阅器类  
            SubscribEvent s = new SubscribEvent();
            e.ChangeNum += new EventTest.NumManipulationHandler(s.Consoles);
            e.SetValue(7);
            e.SetValue(11);
        }
    }
}

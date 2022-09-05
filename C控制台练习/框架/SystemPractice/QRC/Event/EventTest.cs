using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    /// <summary>
    /// 发布器类
    /// </summary>
    public class EventTest
    {
        //私有变量
        private int value;
        //定义一个委托类型
        public delegate void NumManipulationHandler();
        //根据以上的委托类型声明一个事件
        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();//事件触发
            }
            else
            {
                Console.WriteLine("事件不存在");
                Console.ReadKey();
            }
        }
        //构造函数
        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }
        //赋值
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
}

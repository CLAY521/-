using System;
using System.Collections.Generic;
using System.Linq;

namespace FourFilter.Controllers
{
    public interface IService
    {
        //定义一个输出方法
        void ConsoleWord();
    }
    /// <summary>
    /// 服务类具体实现
    /// </summary>
    public class Service: IService
    {
        //默认构造
        public Service()
        {
            Console.WriteLine("我是service的默认构造");
        }
        public void ConsoleWord()
        {
            System.Diagnostics.Debug.WriteLine("调起了service中的方法");
        }
    }
}
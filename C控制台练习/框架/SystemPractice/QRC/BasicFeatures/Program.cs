using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Diao();
            Console.ReadKey();
        }
        public static void Diao()
        {
            Man m = new Man();
            m.Run();
        }
    }
    #region 面向对象的三大特征
    //1.封装：将功能封装起来，方便使用    比如有一些重复使用得方法   可以考虑写成公共方法
    //2.继承：子类继承父类   子类就拥有了父类的方法  属性
    //3.多态：
    //          重载：在一个类中  方法名相同  参数个数或者参数类型不同
    //          重写：在继承关系中，子类和父类中，override   对父类的方法   重新编写
    #endregion
    #region 重写 override

    public class People
    {
        public virtual void Run()
        {
            Console.WriteLine("人类会跑步");
        }
    }
    public class Man : People
    {
        public override void Run()
        {
            Console.WriteLine("子类中有了重写方法   自动执行子类的方法");
        }
    }
    
    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoDelegates
{
    /// <summary>
    /// 多播委托
    /// </summary>
    class Program
    {
        //定义购买商品的委托
        public delegate void OrderDelegate();
        static void Main(string[] args)
        {
            //实例化委托
            OrderDelegate order = new OrderDelegate(Order.BuyFood);
            //向委托中注册方法
            order += Order.BuyCake;
            order += Order.BuyFlower;
            //调用委托
            order();
            Console.ReadKey();
        }
    }
    public class Order
    {
        public static void BuyFood()
        {
            Console.WriteLine("购买快餐！");
        }
        public static void BuyCake()
        {
            Console.WriteLine("购买蛋糕！");
        }
        public static void BuyFlower()
        {
            Console.WriteLine("购买鲜花！");
        }
    }
}

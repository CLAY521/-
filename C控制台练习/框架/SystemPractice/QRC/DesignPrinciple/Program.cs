using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Dependency();
            Console.ReadKey();
        }
        #region 单一功能原则（single-responsibility principle） 规定每个类都应该有且仅有一个单一的功能，并且该功能应该由这个类完全封装起来。
        //public static void Single()
        //{
        //    var shapes = new List<object>
        //    {
        //        new Circle(2),
        //        new Square(5),
        //        new Square(6)
        //    };
        //    var areas = new AreaCalculator(shapes);
        //    Console.WriteLine(areas.OutPut());
        //}
        #endregion

        #region  开闭原则（open-closed principle）
        //public static void Open()
        //{
        //    var shapes = new List<IShape>
        //    {
        //        new Circle(2),
        //        new Square(5)
        //    };
        //    var areaCalculator = new AreaCalculator(shapes);
        //    var outputer = new SumCalculatorOutPutter(areaCalculator);
        //    Console.WriteLine(outputer.String());
        //}
        #endregion

        #region  里氏替换原则（Liskov substitution principle）
        //public static void Liskov()
        //{
        //    Employee e;
        //    e = new Permanent() { Name="张三"};
        //    Console.WriteLine($"{e.Name}的年终奖是{e.CalculateBonus()}元");

        //    e = new Contract() { Name = "李四"};
        //    Console.WriteLine($"{e.Name}的年终奖是{e.CalculateBonus()}元");

        //    e = new TempOrary() { Name="王五"};
        //    Console.WriteLine($"{e.Name}的年终奖是{e.CalculateBonus()}元");

        //}
        #endregion

        #region  接口隔离原则（Interface segregation principle）
        //不应被迫使用对其没用的方法或功能，将庞大臃肿的接口拆分成更小、更具体的接口。解耦
        #endregion

        #region  依赖反转原则（Dependency inversion principle）
        //1.高层对象不依赖于低层对象，两者都应该依赖于抽象接口。
        //2.抽象接口不依赖于具体实现，具体实现应依赖于抽象接口。
        public static void Dependency()
        {
            ProductDataAccess p0 = new ProductDataAccess();
            ProductBusiness p = new ProductBusiness(p0);
            ProductInfo p1 = p.GetProductDetail(2);
            Console.WriteLine(p1.Id + "：" + p1.Name);
        }
        #endregion
    }
    //5大设计原则   SOLID
    #region 单一功能原则（single-responsibility principle） 规定每个类都应该有且仅有一个单一的功能，并且该功能应该由这个类完全封装起来。
    //正方形
    //public class Square
    //{
    //    public Square(double length)
    //    {
    //        SideLength = length;
    //    }
    //    public static double SideLength { get; set; }
    //}
    //圆形
    //public class Circle
    //{
    //    public Circle(double radius)
    //    {
    //        Radius = radius;
    //    }
    //    public static double Radius { get; set; }
    //}
    //public class AreaCalculator
    //{
    //    private List<object> _shapes;
    //    public AreaCalculator(List<object> shapes)
    //    {
    //        _shapes = shapes;
    //    }
    //    public double Sum()
    //    {
    //        List<double> areas = new List<double>();
    //        foreach (var item in _shapes)
    //        {
    //            if (item is Square)
    //            {
    //                areas.Add(Math.Pow(Square.SideLength, 2));
    //            }
    //            else if (item is Circle)
    //            {
    //                areas.Add(Math.PI * Math.Pow(Circle.Radius, 2));
    //            }
    //            else
    //            {

    //            }
    //        }
    //        return areas.Sum();
    //    }
    //    public string OutPut()
    //    {
    //        return $"Sum of the areas of provided shapes:{Sum()}";
    //    }
    //}
    #endregion

    #region  开闭原则（open-closed principle） 允许扩展，但不允许修改。
    //public interface IShape
    //{
    //    double CalcArea();
    //}
    ////正方形
    //public class Square:IShape
    //{
    //    public Square(double length)
    //    {
    //        SideLength = length;
    //    }
    //    public static double SideLength { get; set; }
    //    public double CalcArea()
    //    {
    //        return Math.Pow(SideLength,2);
    //    }
    //}
    ////圆形
    //public class Circle:IShape
    //{
    //    public Circle(double radius)
    //    {
    //        Radius = radius;
    //    }
    //    public static double Radius { get; set; }
    //    public double CalcArea()
    //    {
    //        return Math.PI*Math.Pow(Radius,2);
    //    }
    //}
    //public class AreaCalculator
    //{
    //    private List<IShape> _shapes;
    //    public AreaCalculator(List<IShape> shapes)
    //    {
    //        _shapes = shapes;
    //    }
    //    public double Sum()
    //    {
    //        List<double> areas = new List<double>();
    //        foreach (var item in _shapes)
    //        {
    //            areas.Add(item.CalcArea());
    //        }
    //        return areas.Sum();
    //    }
    //}
    //public class SumCalculatorOutPutter
    //{
    //    protected AreaCalculator _calculator;
    //    public SumCalculatorOutPutter(AreaCalculator calculator)
    //    {
    //        _calculator = calculator;
    //    }
    //    public string String()
    //    {
    //        return $"Sum of the areas of provided shapes:{_calculator.Sum()}";
    //    }
    //}
    #endregion

    #region  里氏替换原则（Liskov substitution principle）子类可以在程序中代替父类
    //public abstract class Employee
    //{
    //    public string Name { get; set; }
    //    public abstract decimal CalculateBonus();
    //}
    //public class Permanent : Employee
    //{
    //    public override decimal CalculateBonus()
    //    {
    //        return 80000;
    //    }
    //}
    //public class Contract : Employee
    //{
    //    public override decimal CalculateBonus()
    //    {
    //        return 2000;
    //    }
    //}
    //public class TempOrary : Employee
    //{
    //    public override decimal CalculateBonus()
    //    {
    //        return 1000;
    //    }
    //}
    #endregion

    #region  接口隔离原则（Interface segregation principle）不应被迫使用对其没用的方法或功能，将庞大臃肿的接口拆分成更小、更具体的接口。解耦
    //不应被迫使用对其没用的方法或功能，将庞大臃肿的接口拆分成更小、更具体的接口。解耦



    #endregion

    #region  依赖反转原则（Dependency inversion principle）
    //1.高层对象不依赖于低层对象，两者都应该依赖于抽象接口。
    //2.抽象接口不依赖于具体实现，具体实现应依赖于抽象接口。
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IProduct
    {
        ProductInfo GetDetail(int id);
    }
    public class ProductDataAccess : IProduct
    {
        public ProductInfo GetDetail(int id)
        {
            ProductInfo product = new ProductInfo()
            {
                Id = id,
                Name = "张三"
            };
            return product;
        }
    }
    public class ProductBusiness
    {
        private readonly IProduct _product;
        public ProductBusiness(IProduct product)
        {
            _product = product;
        }
        public ProductInfo GetProductDetail(int id)
        {
            return _product.GetDetail(id);
        }
    }
    #endregion
}

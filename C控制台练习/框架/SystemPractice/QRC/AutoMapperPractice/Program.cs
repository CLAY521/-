using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Profile();

            Console.ReadKey();
        }

        #region 创建两个类之间的联系（使用automapper映射）

        public static void AutoMapperBasic()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorDTO>();
            });
            IMapper iMpper = config.CreateMapper();
            var source = new AuthorModel();
            source.Id = 1;
            source.FirstName = "Joydip";
            source.LastName = "Kanjilal";
            var destination = iMpper.Map<AuthorModel, AuthorDTO>(source);
            Console.WriteLine("FirstName Name:" + destination.FirstName + "\n" + "LastName Name:" + destination.LastName);
        }

        #endregion

        #region Projections功能
        public static void ProjectionsPractice()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTO, AuthorModel>()
                .ForMember(destination => destination.Address,
                map => map.MapFrom(
                    source => new Address
                    {
                        City = source.City,
                        State = source.State,
                        Country = source.Country
                    }
                    ));
            });
            IMapper iMpper = config.CreateMapper();
            AuthorDTO add = new AuthorDTO();
            add.City = "杭州";
            add.Country = "中国";
            add.State = "健康";
            var des = iMpper.Map<AuthorDTO, AuthorModel>(add);
            Console.WriteLine("City:" + des.Address.City + "\n" + "Country:" + des.Address.Country + "\n" + "State:" + des.Address.State);
        }
        #endregion

        #region 简单功能
        public static void Simple()
        {
            //配置两者的关系
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Foo, FooDto>());
            //创建两者关系
            var mapper = config.CreateMapper();
            //给其中一个赋值
            Foo foo = new Foo { Id=1,Name="张三"};
            //将第一个的值映射到第二个实体上
            FooDto dto = mapper.Map<FooDto>(foo);
            //输出第二个实体的信息
            Console.WriteLine($"ID：{ dto.Id}\n姓名：{ dto.Name}");
        }
        public static void Profile()
        {
            //配置两者的关系
            var config = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>());
            //创建两者关系
            var mapper = config.CreateMapper();
            //给其中一个赋值
            Foo foo = new Foo { Id = 1, Name = "张三" };
            //将第一个的值映射到第二个实体上
            FooDto dto = mapper.Map<FooDto>(foo);
            //输出第二个实体的信息
            Console.WriteLine($"ID：{ dto.Id}\n姓名：{ dto.Name}");
        }
        #endregion
    }

    #region 简单功能的实体
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FooDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region 头两个例子涉及到的实体
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class AuthorModel
    {
        public int Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public Address Address
        {
            get; set;
        }
    }

    public class AuthorDTO
    {
        public int Id
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    #endregion
}

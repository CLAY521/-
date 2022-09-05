using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperPractice
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Foo, FooDto>();
        }

    }
}

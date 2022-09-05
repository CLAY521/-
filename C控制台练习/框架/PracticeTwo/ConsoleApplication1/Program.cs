using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Http报文分为  请求报文和响应报文

            //一个Http报文由3部分组成  分别是
            //1.起始行（start line）
            //2.首部（header）
            //3.主题（body）

            //示例：

            //  HTTP / 1.0 200 OK    //起始行

            //  Content - type:text / plain    //首部
            //  Content - length:19            //首部  

            //  Hi I'm a message!    主体





            Console.ReadKey();
        }
    }
}

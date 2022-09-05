using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.CookieModel
{
    public class AdminTicket:ICookieModel
    {
        public string GetCookieKey()
        {
            return "pc.Admin";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FourFilter.Controllers
{
    public class TestMvcAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var result = new Grade() {Mes="授权中" };
            if (Users == "admin")
            {
                return;
            }
            else
            {

            }
        }
    }
}
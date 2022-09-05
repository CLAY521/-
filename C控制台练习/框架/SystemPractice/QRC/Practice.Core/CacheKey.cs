using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core
{
    public class CacheKey
    {
        public static readonly string AllModuleKey = "AllModule";
        public static readonly string AdminUserModuleKey = "UserModule:{0}";
        public static readonly string LoginKey = "Login:{0}";
        public static readonly string LoginOnceKey = "OnceKey:{0}";
    }
}

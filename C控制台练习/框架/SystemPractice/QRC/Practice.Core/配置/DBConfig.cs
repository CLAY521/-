using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.配置
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    [Serializable]
    public class DBConfig:IConfig
    {
        private string _connectionString;
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        #region path
        public string GetConfigPath()
        {
            return "//App_Data/db.config";
        }
        #endregion
    }
}

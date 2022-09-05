using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerEventApp
{
    /// <summary>
    /// 发布器
    /// </summary>
    public class DelegateBoilerEvent
    {
        //定义委托
        public delegate void BoilerLogHandler(string status);
        //声明事件
        public event BoilerLogHandler BoilerEventLog;
        public void LogProcess(BoilerLogHandler r)
        {
            string remarks = "O.K";
            Boiler b = new Boiler(100,12);
            int t = b.getTemp();
            int p = b.getPressure();
            if (t > 150 || t < 80 || p < 12 || p > 15)
            {
                remarks = "需要维修";
            }
            OnBoilerInfoLog(r,"日志信息:\n");
            OnBoilerInfoLog(r, "温度:" +t+"\n压力："+p);
            OnBoilerInfoLog(r, "\n提示:" +remarks);
        }
        protected void OnBoilerInfoLog(BoilerLogHandler r,string message)
        {
            if (r != null)
            {
                r(message);
            }
        }
    }
}

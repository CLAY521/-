using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerEventApp
{
    /// <summary>
    /// 锅炉日志
    /// </summary>
    public class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;
        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename,FileMode.OpenOrCreate,FileAccess.Write);
            sw = new StreamWriter(fs);
        }
        public void Logger(string info)
        {
            sw.WriteLine(info);
        }
        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
}

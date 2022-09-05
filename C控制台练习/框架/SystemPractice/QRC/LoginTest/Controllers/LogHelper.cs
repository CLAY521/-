using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LoginTest.Controllers
{
    //日志记录
    public class LogHelper
    {
        /// <summary>
        /// 一般信息日志
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="ex"></param>
        /// <param name="level"></param>
        public static void InfoLog(string logContent, Exception ex = null, Log4NetLevel level = Log4NetLevel.Info)
        {
            WriteLog(logContent,ex,LogType.InfoLog,level);
        }
        /// <summary>
        /// 需要有路径的日志中  访问日志
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="ex"></param>
        /// <param name="level"></param>
        public static void UrlLog(string logContent, Exception ex = null, Log4NetLevel level = Log4NetLevel.Info)
        {
            WriteLog(logContent, ex, LogType.InfoLog, level);
        }
        /// <summary>
        /// 系统日志错误  （一般在错误过滤器中）   
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="ex"></param>
        /// <param name="level"></param>
        public static void SysErrorLog(string logContent, Exception ex = null, Log4NetLevel level = Log4NetLevel.Error)
        {
            WriteLog(logContent, ex, LogType.InfoLog, level);
        }
        /// <summary>
        /// 一般错误日志   在可能报错的地方
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="ex"></param>
        /// <param name="level"></param>
        public static void ErrorLog(string logContent, Exception ex = null, Log4NetLevel level = Log4NetLevel.Error)
        {
            WriteLog(logContent, ex, LogType.InfoLog, level);
        }
        /// <summary>
        /// 第三方接口的时候   第三方接口日志
        /// </summary>
        /// <param name="logContent"></param>
        /// <param name="ex"></param>
        /// <param name="level"></param>
        public static void ThirdLog(string logContent, Exception ex = null, Log4NetLevel level = Log4NetLevel.Info)
        {
            WriteLog(logContent, ex, LogType.InfoLog, level);
        }
        /// <summary>
        /// 调用Log4net写日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <param name="loType"></param>
        /// <param name="log4Level"></param>
        public static void WriteLog(string msg,Exception ex =null, LogType loType = LogType.InfoLog,Log4NetLevel log4Level = Log4NetLevel.Info)
        {
            //日志实例   日志添加成功后,按照时间分类，然后按照logType的枚举进行分类   配置文件中的配置相关All
            ILog log = LogManager.GetLogger(loType.ToString());
            switch (log4Level)
            {
                case Log4NetLevel.Debug:
                    log.Debug(msg, ex);
                    break;
                case Log4NetLevel.Error:
                    log.Error(msg, ex);
                    break;
                case Log4NetLevel.Fatal:
                    log.Fatal(msg, ex);
                    break;
                case Log4NetLevel.Warn:
                    log.Warn(msg, ex);
                    break;
                default:
                    log.Info(msg, ex);
                    break;
            }
        }
    }
    public enum Log4NetLevel
    {
        [Description("调试信息")]
        Debug = 0,
        [Description("错误日志")]
        Error = 1,
        [Description("严重错误")]
        Fatal = 2,
        [Description("一般信息")]
        Info = 3,
        [Description("警告信息")]
        Warn = 4
    }
    public enum LogType
    {
        InfoLog,
        SysErrorLog,
        ErrorLog,
        UrlLog,
        ThirdLog
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.配置
{
    public class PracticeConfig:IConfig
    {
        private string _cdnpath;
        public string CdnPath
        {
            get { return _cdnpath; }
            set { _cdnpath = value; }
        }
        #region 日志配置
        private bool _isWriteCommonLogToLocalFile;
        //是否把一般日志写到本地
        public bool IsWriteCommonLogToLocalFile
        {
            get { return _isWriteCommonLogToLocalFile; }
            set { _isWriteCommonLogToLocalFile = value; }
        }
        private bool _isWriteErrorLogToLocalFile;
        //错误日志写入本地文件
        public bool boolIsWriterErrorLlogToLocalFile
        {
            get { return _isWriteErrorLogToLocalFile; }
            set { _isWriteErrorLogToLocalFile = value; }
        }
        private bool _isWriteTimeWatchLogToLocalFile;

        /// <summary>
        /// 写耗时日志到本地
        /// </summary>
        public bool IsWriteTimeWatchLogToLocalFile
        {
            get { return _isWriteTimeWatchLogToLocalFile; }
            set { _isWriteTimeWatchLogToLocalFile = value; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// 是否监控请求效率
        /// </summary>
        public bool Profiler { get; set; }
        #region 阿里云相关

        public string AliyunEndpoint { get; set; }

        public string AliyunAccessKeyId { get; set; }

        public string AliyunAccessKeySecret { get; set; }

        /// <summary>
        /// 后台统一上传存储空间
        /// </summary>
        public string AliyunBucket { get; set; }

        #endregion

        public string ErpUrl { get; set; }

        public string ErpOrderMethod { get; set; }
        public string ErpOrderInfoMethod { get; set; }

        /// <summary>
        /// 工单接口
        /// </summary>
        public string ErpWorkInfo { get; set; }
        #endregion 
        public string GetConfigPath()
        {
            return "/Ap_Data/Practice.config";
        }
    }
}

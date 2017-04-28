

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Xiuse.Model
{
    public class SysLog
    {
        private String _LogId;
        private String _UserId;
        private String _LogContent;
        private int _LogType;
        private DateTime _LogTime;
        /// <summary>
        /// 请求的Action 参数
        /// </summary>
        public Dictionary<string, object> ActionParams
        {
            get;
            set;
        }
        /// <summary>
        /// Http请求头
        /// </summary>
        public string HttpRequestHeaders
        {
            get;
            set;
        }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod
        {
            get;
            set;
        }
        public string LogId
        {
            get
            {
                return _LogId;
            }
            set
            {
                _LogId = value;
            }
        }
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        public string LogContent
        {
            get
            {
                return _LogContent;
            }
            set
            {
                _LogContent = value;
            }
        }
        public int LogType
        {
            get
            {
                return _LogType;
            }
            set
            {
                _LogType = value;
            }
        }
        public DateTime LogTime
        {
            get
            {
                return _LogTime;
            }
            set
            {
                _LogTime = value;
            }
        }
    }
}
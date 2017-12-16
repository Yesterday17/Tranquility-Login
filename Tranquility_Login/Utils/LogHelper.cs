using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tranquility_Login.Utils
{
    public class LogHelper
    {
        /// <summary>
        /// 自身实例
        /// </summary>
        public static LogHelper logger = new LogHelper();

        /// <summary>
        /// 写入Info日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public void info(string message)
        {
            //
        }
        
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">写入的信息</param>
        /// <param name="title">写入信息的单位</param>
        /// <param name="status">日志等级</param>
        public void log(string message, string title, string status)
        {
            string time = $"[{DateTime.Now.GetDateTimeFormats('t')}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base
{
    /// <summary>
    /// 游戏框架日志类。
    /// </summary>
    public static class GameFrameworkLog
    {
        private static ILogHelper s_LogHelper;

        /// <summary>
        /// 设置日志辅助器。
        /// </summary>
        /// <param name="logHelper">要设置的日志辅助器。</param>
        public static void SetLogHelper(ILogHelper logHelper)
        {
            s_LogHelper = logHelper;
        }

        /// <summary>
        /// 打印调试级别日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Debug(string message)
        {
            s_LogHelper?.Log(GameFrameworkLogLevel.Debug, message);
        }

        /// <summary>
        /// 打印信息级别日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Info(string message)
        {
            s_LogHelper?.Log(GameFrameworkLogLevel.Info, message);
        }

        /// <summary>
        /// 打印警告级别日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Warning(string message)
        {
            s_LogHelper?.Log(GameFrameworkLogLevel.Warning, message);
        }

        /// <summary>
        /// 打印错误级别日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Error(string message)
        {
            s_LogHelper?.Log(GameFrameworkLogLevel.Error, message);
        }

        /// <summary>
        /// 打印严重错误级别日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public static void Fatal(string message)
        {
            s_LogHelper?.Log(GameFrameworkLogLevel.Fatal, message);
        }
    }

    /// <summary>
    /// 日志辅助器接口。
    /// </summary>
    public interface ILogHelper
    {
        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">游戏框架日志等级。</param>
        /// <param name="message">日志内容。</param>
        void Log(GameFrameworkLogLevel level, string message);
    }

}

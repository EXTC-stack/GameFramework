using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base
{
    /// <summary>
    /// 游戏框架异常类。
    /// </summary>
    public class GameFrameworkException : Exception
    {
        /// <summary>
        /// 初始化游戏框架异常类的新实例。
        /// </summary>
        public GameFrameworkException()
            : base()
        {
        }

        /// <summary>
        /// 使用指定错误消息初始化游戏框架异常类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public GameFrameworkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化游戏框架异常类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        /// <param name="innerException">导致当前异常的异常。</param>
        public GameFrameworkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// 游戏框架日志等级。
    /// </summary>
    public enum GameFrameworkLogLevel
    {
        /// <summary>
        /// 调试。
        /// </summary>
        Debug = 0,

        /// <summary>
        /// 信息。
        /// </summary>
        Info = 1,

        /// <summary>
        /// 警告。
        /// </summary>
        Warning = 2,

        /// <summary>
        /// 错误。
        /// </summary>
        Error = 3,

        /// <summary>
        /// 严重错误。
        /// </summary>
        Fatal = 4
    }
}

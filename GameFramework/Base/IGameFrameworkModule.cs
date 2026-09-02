using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base
{
    public interface IGameFrameworkModule
    {
        /// <summary>
        /// 模块优先级，数字越小越早被 Update
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 模块更新，每帧调用
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间（受 Time.timeScale 影响）</param>
        /// <param name="realElapseSeconds">真实流逝时间（不受 timeScale 影响）</param>
        void Update(float elapseSeconds, float realElapseSeconds);

        /// <summary>
        /// 关闭模块，释放资源
        /// </summary>
        void Shutdown();
    }
}

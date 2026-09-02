using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base
{
    public abstract class GameFrameworkModule : IGameFrameworkModule
    {
        /// <summary>
        /// 模块优先级，子类必须重写
        /// </summary>
        public abstract int Priority { get; }

        /// <summary>
        /// 模块更新，子类按需重写
        /// </summary>
        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {

        }

        /// <summary>
        /// 关闭模块，子类按需重写
        /// </summary>
        public virtual void Shutdown()
        {

        }
    }
}

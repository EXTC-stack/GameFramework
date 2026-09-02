using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public abstract class FsmBase
    {
        // 状态机名称
        public string Name { get; protected set; }

        // 当前状态名称
        public abstract string CurrentStateName { get; }

        // 是否已销毁
        public bool IsDestroyed { get; protected set; }

        // 内部更新方法（由 FsmManager 调用）
        internal abstract void Update(float elapseSeconds, float realElapseSeconds);

        // 内部关闭方法
        internal abstract void Shutdown();
    }
}

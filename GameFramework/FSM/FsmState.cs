using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public abstract class FsmState<T> where T : class
    {
        // 状态所属状态机（进入时自动设置）
        protected internal IFsm<T> Fsm { get; private set; }

        // 进入状态
        protected internal virtual void OnEnter(IFsm<T> fsm) { }

        // 每帧更新
        protected internal virtual void OnUpdate(IFsm<T> fsm, float elapseSeconds, float realElapseSeconds) { }

        // 离开状态
        protected internal virtual void OnLeave(IFsm<T> fsm, bool isShutdown) { }

        // 状态机销毁时调用
        protected internal virtual void OnDestroy(IFsm<T> fsm) { }

        // 切换状态（便捷方法）
        protected void ChangeState<TState>(IFsm<T> fsm) where TState : FsmState<T>
        {
            fsm.ChangeState<TState>();
        }
    }
}

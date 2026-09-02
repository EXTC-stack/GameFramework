using GameFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public sealed class FsmManager : GameFrameworkModule, IFsmManager
    {
        private readonly Dictionary<string, FsmBase> m_Fsms = new();

        public int Priority => -1;  // 优先级较高

        public int Count => m_Fsms.Count;

        public IFsm<T> CreateFsm<T>(T owner, params FsmState<T>[] states) where T : class
        {

        }
        public IFsm<T> CreateFsm<T>(string name, T owner, params FsmState<T>[] states) where T : class
        {
            
        }
        public bool DestroyFsm<T>() where T : class
        {
            return true;
        }
        public bool DestroyFsm<T>(string name) where T : class
        {
            return true;
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            // 遍历所有状态机，调用它们的 Update
            foreach (var fsm in m_Fsms.Values)
            {
                if (fsm.IsDestroyed) continue;
                fsm.Update(elapseSeconds, realElapseSeconds);
            }
        }

        public override void Shutdown()
        {
            // 销毁所有状态机
            foreach (var fsm in m_Fsms.Values)
            {
                fsm.Shutdown();
            }
            m_Fsms.Clear();
        }
    }
}

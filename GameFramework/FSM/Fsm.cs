using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public sealed class Fsm<T> : FsmBase, IFsm<T> where T : class
    {
        private T m_Owner;
        private readonly Dictionary<string, FsmState<T>> m_States;      // 所有状态
        private readonly Dictionary<string, object> m_Datas;            // 共享数据
        private FsmState<T> m_CurrentState;
        private float m_CurrentStateTime;

        public T Owner ;

        public FsmState<T> CurrentState ;

        public float CurrentStateTime;

        // 构造方法（私有，通过 FsmManager 创建）
        private Fsm(string name, T owner)
        {

        }

        public Fsm()
        {

        }

        // 创建方法（静态内部调用）
        internal static Fsm<T> Create(string name, T owner, params FsmState<T>[] states)
        {
            return new Fsm<T>();
        }

        // 启动状态机
        public void Start<TState>() where TState : FsmState<T>
        {

        }

        // 切换状态（核心！）
        public void ChangeState<TState>() where TState : FsmState<T>
        {

        }

        // 每帧更新当前状态
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {

        }

        // 关闭状态机
        internal override void Shutdown()
        {

        }

        public bool HasState<TState>() where TState : FsmState<T>
        {
            
        }

        public TState GetState<TState>() where TState : FsmState<T>
        {
            
        }

        public TData GetData<TData>(string name)
        {
            
        }

        public void SetData(string name, object data)
        {
            
        }

        public bool RemoveData(string name)
        {
            
        }
    }
}

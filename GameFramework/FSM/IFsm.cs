using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public interface IFsm<T> where T : class
    {
        string Name { get; }
        T Owner { get; }                          // 状态机持有者
        FsmState<T> CurrentState { get; }         // 当前状态
        string CurrentStateName { get; }
        float CurrentStateTime { get; }           // 当前状态已持续时间

        // 启动状态机，进入初始状态
        void Start<TState>() where TState : FsmState<T>;

        // 切换状态
        void ChangeState<TState>() where TState : FsmState<T>;

        // 检查是否存在某状态
        bool HasState<TState>() where TState : FsmState<T>;

        // 获取某状态
        TState GetState<TState>() where TState : FsmState<T>;

        // 获取状态数据
        TData GetData<TData>(string name);
        void SetData(string name, object data);
        bool RemoveData(string name);
    }
}

using GameFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.FSM
{
    public interface IFsmManager : IGameFrameworkModule
    {
        // 状态机数量
        int Count { get; }

        // 创建状态机
        IFsm<T> CreateFsm<T>(T owner, params FsmState<T>[] states) where T : class;
        IFsm<T> CreateFsm<T>(string name, T owner, params FsmState<T>[] states) where T : class;

        // 销毁状态机
        bool DestroyFsm<T>() where T : class;
        bool DestroyFsm<T>(string name) where T : class;

        // 获取状态机
        IFsm<T> GetFsm<T>() where T : class;
        IFsm<T> GetFsm<T>(string name) where T : class;

        // 是否存在
        bool HasFsm<T>() where T : class;
        bool HasFsm<T>(string name) where T : class;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base
{
    /// <summary>
    /// 游戏框架入口。
    /// </summary>
    public static class GameFrameworkEntry
    {
        private static readonly LinkedList<IGameFrameworkModule> s_GameFrameworkModules = new LinkedList<IGameFrameworkModule>();
        private static readonly Dictionary<Type, IGameFrameworkModule> s_GameFrameworkModuleCache = new Dictionary<Type, IGameFrameworkModule>();

        /// <summary>
        /// 获取游戏框架模块。
        /// </summary>
        /// <typeparam name="T">要获取的游戏框架模块类型。</typeparam>
        /// <returns>要获取的游戏框架模块。</returns>
        /// <remarks>如果模块不存在，则自动创建并注册。</remarks>
        public static T GetModule<T>() where T : class, IGameFrameworkModule
        {
            Type interfaceType = typeof(T);

            // 先从缓存查找
            if (s_GameFrameworkModuleCache.TryGetValue(interfaceType, out IGameFrameworkModule module))
            {
                return (T)module;
            }

            // 遍历链表查找实现了该接口的模块
            foreach (IGameFrameworkModule gameFrameworkModule in s_GameFrameworkModules)
            {
                if (gameFrameworkModule is T t)
                {
                    s_GameFrameworkModuleCache.Add(interfaceType, gameFrameworkModule);
                    return t;
                }
            }

            // 未找到，尝试自动创建
            return CreateModule<T>();
        }

        /// <summary>
        /// 创建模块实例（通过反射）。
        /// </summary>
        private static T CreateModule<T>() where T : class, IGameFrameworkModule
        {
            // 查找实现了接口 T 的具体类型
            Type interfaceType = typeof(T);
            Type implementType = null;

            // 遍历当前程序集的所有类型
            foreach (Type type in Utility.Assembly.GetTypes())
            {
                if (interfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                {
                    implementType = type;
                    break;
                }
            }

            if (implementType == null)
            {
                throw new GameFrameworkException($"Can not find implement type of '{interfaceType.FullName}'.");
            }

            IGameFrameworkModule module = (IGameFrameworkModule)Activator.CreateInstance(implementType);
            RegisterModule(module);

            s_GameFrameworkModuleCache.Add(interfaceType, module);
            return (T)module;
        }

        /// <summary>
        /// 注册游戏框架模块。
        /// </summary>
        /// <param name="gameFrameworkModule">要注册的游戏框架模块。</param>
        internal static void RegisterModule(IGameFrameworkModule gameFrameworkModule)
        {
            if (gameFrameworkModule == null)
            {
                throw new GameFrameworkException("Game framework module is invalid.");
            }

            Type moduleType = gameFrameworkModule.GetType();

            // 检查是否已注册
            foreach (IGameFrameworkModule module in s_GameFrameworkModules)
            {
                if (module.GetType() == moduleType)
                {
                    throw new GameFrameworkException($"Game framework module '{moduleType.FullName}' already exist.");
                }
            }

            // 按优先级插入链表（保持有序）
            LinkedListNode<IGameFrameworkModule> current = s_GameFrameworkModules.First;
            while (current != null)
            {
                if (current.Value.Priority > gameFrameworkModule.Priority)
                {
                    s_GameFrameworkModules.AddBefore(current, gameFrameworkModule);
                    return;
                }

                current = current.Next;
            }

            // 优先级最低，放到最后
            s_GameFrameworkModules.AddLast(gameFrameworkModule);
        }

        /// <summary>
        /// 取消注册游戏框架模块。
        /// </summary>
        /// <param name="gameFrameworkModule">要取消注册的游戏框架模块。</param>
        internal static void UnregisterModule(IGameFrameworkModule gameFrameworkModule)
        {
            if (gameFrameworkModule == null)
            {
                throw new GameFrameworkException("Game framework module is invalid.");
            }

            Type moduleType = gameFrameworkModule.GetType();

            // 从缓存中移除
            List<Type> keysToRemove = new List<Type>();
            foreach (KeyValuePair<Type, IGameFrameworkModule> cache in s_GameFrameworkModuleCache)
            {
                if (cache.Value.GetType() == moduleType)
                {
                    keysToRemove.Add(cache.Key);
                }
            }
            foreach (Type key in keysToRemove)
            {
                s_GameFrameworkModuleCache.Remove(key);
            }

            // 从链表中移除
            if (!s_GameFrameworkModules.Remove(gameFrameworkModule))
            {
                throw new GameFrameworkException($"Game framework module '{moduleType.FullName}' not exist.");
            }
        }

        /// <summary>
        /// 获取所有游戏框架模块。
        /// </summary>
        /// <returns>所有游戏框架模块。</returns>
        public static IGameFrameworkModule[] GetAllModules()
        {
            int index = 0;
            IGameFrameworkModule[] results = new IGameFrameworkModule[s_GameFrameworkModules.Count];
            foreach (IGameFrameworkModule module in s_GameFrameworkModules)
            {
                results[index++] = module;
            }

            return results;
        }

        /// <summary>
        /// 所有游戏框架模块轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        public static void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach (IGameFrameworkModule module in s_GameFrameworkModules)
            {
                module.Update(elapseSeconds, realElapseSeconds);
            }
        }

        /// <summary>
        /// 关闭并清理所有游戏框架模块。
        /// </summary>
        public static void Shutdown()
        {
            // 按优先级逆序关闭
            LinkedListNode<IGameFrameworkModule> current = s_GameFrameworkModules.Last;
            while (current != null)
            {
                current.Value.Shutdown();
                current = current.Previous;
            }

            s_GameFrameworkModules.Clear();
            s_GameFrameworkModuleCache.Clear();
        }
    }

}

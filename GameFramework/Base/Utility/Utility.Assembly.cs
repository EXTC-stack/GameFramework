using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base.Utility
{
    public static partial class Utility
    {
        /// <summary>
        /// 程序集相关的实用函数。
        /// </summary>
        public static class Assembly
        {
            private static readonly HashSet<string> s_AssemblyNames = new HashSet<string>();
            private static readonly Dictionary<string, Type> s_CachedTypes = new Dictionary<string, Type>(StringComparer.Ordinal);

            static Assembly()
            {
                // 加载当前 AppDomain 的所有程序集名称
                System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (System.Reflection.Assembly assembly in assemblies)
                {
                    s_AssemblyNames.Add(assembly.FullName);
                }
            }

            /// <summary>
            /// 获取已加载的程序集名称集合。
            /// </summary>
            public static HashSet<string> AssemblyNames
            {
                get
                {
                    return s_AssemblyNames;
                }
            }

            /// <summary>
            /// 获取当前程序集的所有类型。
            /// </summary>
            /// <returns>当前程序集的所有类型。</returns>
            public static Type[] GetTypes()
            {
                List<Type> results = new List<Type>();
                System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (System.Reflection.Assembly assembly in assemblies)
                {
                    results.AddRange(assembly.GetTypes());
                }

                return results.ToArray();
            }

            /// <summary>
            /// 获取指定程序集中的所有类型。
            /// </summary>
            /// <param name="assemblyName">程序集名称。</param>
            /// <returns>指定程序集中的所有类型。</returns>
            public static Type[] GetTypes(string assemblyName)
            {
                System.Reflection.Assembly assembly = null;
                try
                {
                    assembly = System.Reflection.Assembly.Load(assemblyName);
                }
                catch
                {
                    return new Type[0];
                }

                if (assembly == null)
                {
                    return new Type[0];
                }

                return assembly.GetTypes();
            }

            /// <summary>
            /// 获取已加载的程序集中的所有类型。
            /// </summary>
            /// <returns>已加载的程序集中的所有类型。</returns>
            public static Type[] GetLoadedTypes()
            {
                List<Type> results = new List<Type>();
                System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (System.Reflection.Assembly assembly in assemblies)
                {
                    results.AddRange(assembly.GetTypes());
                }

                return results.ToArray();
            }
        }
    }
}

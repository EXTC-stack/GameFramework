using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base.ReferencePool
{
    /// <summary>
    /// 引用池。
    /// </summary>
    public static class ReferencePool
    {
        private static readonly Dictionary<Type, ReferenceCollection> s_ReferenceCollections = new Dictionary<Type, ReferenceCollection>();

        /// <summary>
        /// 获取引用池的数量。
        /// </summary>
        public static int Count
        {
            get
            {
                return s_ReferenceCollections.Count;
            }
        }

        /// <summary>
        /// 获取引用池中所有引用的总数量。
        /// </summary>
        public static int TotalCount
        {
            get
            {
                int totalCount = 0;
                foreach (ReferenceCollection referenceCollection in s_ReferenceCollections.Values)
                {
                    totalCount += referenceCollection.Count;
                }

                return totalCount;
            }
        }

        /// <summary>
        /// 获取引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <returns>获取的引用。</returns>
        public static T Acquire<T>() where T : class, IReference, new()
        {
            return GetReferenceCollection(typeof(T)).Acquire<T>();
        }

        /// <summary>
        /// 释放引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <param name="reference">要释放的引用。</param>
        public static void Release<T>(T reference) where T : class, IReference
        {
            if (reference == null)
            {
                throw new GameFrameworkException("Reference is invalid.");
            }

            GetReferenceCollection(typeof(T)).Release(reference);
        }

        /// <summary>
        /// 添加引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <param name="count">添加数量。</param>
        public static void Add<T>(int count) where T : class, IReference, new()
        {
            GetReferenceCollection(typeof(T)).Add<T>(count);
        }

        /// <summary>
        /// 移除引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <param name="count">移除数量。</param>
        public static void Remove<T>(int count) where T : class, IReference
        {
            GetReferenceCollection(typeof(T)).Remove(count);
        }

        /// <summary>
        /// 清理引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        public static void Clear<T>() where T : class, IReference
        {
            GetReferenceCollection(typeof(T)).Clear();
        }

        /// <summary>
        /// 清理所有引用。
        /// </summary>
        public static void ClearAll()
        {
            foreach (ReferenceCollection referenceCollection in s_ReferenceCollections.Values)
            {
                referenceCollection.Clear();
            }

            s_ReferenceCollections.Clear();
        }

        /// <summary>
        /// 获取引用集合。
        /// </summary>
        /// <param name="referenceType">引用类型。</param>
        /// <returns>引用集合。</returns>
        private static ReferenceCollection GetReferenceCollection(Type referenceType)
        {
            if (referenceType == null)
            {
                throw new GameFrameworkException("Reference type is invalid.");
            }

            if (!referenceType.IsClass || referenceType.IsAbstract)
            {
                throw new GameFrameworkException("Reference type is not a non-abstract class.");
            }

            if (!typeof(IReference).IsAssignableFrom(referenceType))
            {
                throw new GameFrameworkException($"Reference type '{referenceType.FullName}' does not implement IReference.");
            }

            if (!s_ReferenceCollections.TryGetValue(referenceType, out ReferenceCollection referenceCollection))
            {
                referenceCollection = new ReferenceCollection(referenceType);
                s_ReferenceCollections.Add(referenceType, referenceCollection);
            }

            return referenceCollection;
        }
    }
}

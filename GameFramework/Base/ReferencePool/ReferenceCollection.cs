using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base.ReferencePool
{
    /// <summary>
    /// 引用集合。
    /// </summary>
    internal sealed class ReferenceCollection
    {
        private readonly Queue<IReference> m_References;
        private readonly Type m_ReferenceType;

        /// <summary>
        /// 初始化引用集合的新实例。
        /// </summary>
        /// <param name="referenceType">引用类型。</param>
        public ReferenceCollection(Type referenceType)
        {
            m_References = new Queue<IReference>();
            m_ReferenceType = referenceType;
        }

        /// <summary>
        /// 获取引用类型。
        /// </summary>
        public Type ReferenceType
        {
            get
            {
                return m_ReferenceType;
            }
        }

        /// <summary>
        /// 获取引用数量。
        /// </summary>
        public int Count
        {
            get
            {
                return m_References.Count;
            }
        }

        /// <summary>
        /// 获取引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <returns>获取的引用。</returns>
        public T Acquire<T>() where T : class, IReference, new()
        {
            if (m_References.Count > 0)
            {
                return (T)m_References.Dequeue();
            }

            return new T();
        }

        /// <summary>
        /// 释放引用。
        /// </summary>
        /// <param name="reference">要释放的引用。</param>
        public void Release(IReference reference)
        {
            if (reference == null)
            {
                throw new GameFrameworkException("Reference is invalid.");
            }

            if (reference.GetType() != m_ReferenceType)
            {
                throw new GameFrameworkException("Reference type mismatch.");
            }

            reference.Clear();
            m_References.Enqueue(reference);
        }

        /// <summary>
        /// 添加引用。
        /// </summary>
        /// <typeparam name="T">引用类型。</typeparam>
        /// <param name="count">添加数量。</param>
        public void Add<T>(int count) where T : class, IReference, new()
        {
            while (count-- > 0)
            {
                m_References.Enqueue(new T());
            }
        }

        /// <summary>
        /// 移除引用。
        /// </summary>
        /// <param name="count">移除数量。</param>
        public void Remove(int count)
        {
            if (count > m_References.Count)
            {
                count = m_References.Count;
            }

            while (count-- > 0)
            {
                m_References.Dequeue();
            }
        }

        /// <summary>
        /// 清理引用。
        /// </summary>
        public void Clear()
        {
            m_References.Clear();
        }
    }
}

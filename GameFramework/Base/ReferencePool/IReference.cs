using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Base.ReferencePool
{
    public interface IReference
    {
        // 归还到池子前调用，清空数据
        void Clear();
    }
}

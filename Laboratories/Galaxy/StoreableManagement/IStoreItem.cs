using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreableManagement
{
    public interface IStoreItem<T>
        where T : IStoreable
    {

    }
}

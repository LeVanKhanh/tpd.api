using System;
using System.Collections;

namespace Tpd.Api.Core.Service.ResultBases
{
    public class SingleResult<T> : ResultBase<T>, ISingleResult<T>
       where T : new()
    {
        public SingleResult()
        {
            var T = new T();
            if (T is IEnumerable)
            {
                throw new Exception();
            }
        }
    }
}

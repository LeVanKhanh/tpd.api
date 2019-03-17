using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public abstract class ResultBase<T> : IResultBase<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public interface IResultBase<T>
    {
        bool Success { get; set; }
        List<string> ErrorMessages { get; set; }
        T Result { get; set; }
    }
}

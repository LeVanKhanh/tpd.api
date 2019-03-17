using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public interface IListResult<T>: ICollectionResult<List<T>>
    {
        int TotalRow { get; set; }
    }
}

using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public class ListResult<T> : CollectionResult<List<T>>, IListResult<T>
    {
        public int TotalRow { get; set; }
    }
}

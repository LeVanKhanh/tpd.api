using Tpd.Api.Core.Service.ResultBases;
using System.Collections;

namespace Tpd.Api.Core.Service.QueryResultBases
{
    public interface IQueryCollectionResultBase<T> : ICollectionResult<T>
        where T : IEnumerable
    {
    }
}

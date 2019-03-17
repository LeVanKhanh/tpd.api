using Tpd.Api.Core.Service.ResultBases;
using System.Collections;

namespace Tpd.Api.Core.Service.QueryResultBases
{
    public class QueryCollectionResultBase<T> : CollectionResult<T>, IQueryCollectionResultBase<T>
        where T : IEnumerable
    {

    }
}

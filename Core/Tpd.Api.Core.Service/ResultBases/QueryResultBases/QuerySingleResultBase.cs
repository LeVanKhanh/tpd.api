using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.QueryResultBases
{
    public class QuerySingleResultBase<T>: SingleResult<T>, IQuerySingleResultBase<T>
        where T:new()
    {

    }
}

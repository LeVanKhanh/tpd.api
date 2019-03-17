using Tpd.Api.Core.Service.ResultBases;
using System.Collections.Generic;

namespace Tpd.Api.Core.Service.QueryResultBases
{
    public interface IQueryListResultBase<T> : IListResult<T>,
        IQueryCollectionResultBase<List<T>>
    {

    }
}

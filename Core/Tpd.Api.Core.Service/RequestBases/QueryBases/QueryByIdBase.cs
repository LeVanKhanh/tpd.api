using System;

namespace Tpd.Api.Core.Service.RequestBases.QueryBases
{
    public class QueryByIdBase: QuerySingleBase, IQueryByIdBase
    {
        public Guid Id { get; set; }
    }
}

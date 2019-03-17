using Tpd.Api.Core.Service.RequestBases.QueryBases;
using System;

namespace Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties
{
    public class MasterDataCategoryGetItemQuery: QuerySingleBase
    {
        public Guid Id { get; set; }
    }
}

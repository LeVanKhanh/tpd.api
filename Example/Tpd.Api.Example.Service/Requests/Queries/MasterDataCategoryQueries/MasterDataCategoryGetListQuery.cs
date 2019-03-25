using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueries
{
    public class MasterDataCategoryGetListQuery: QueryListBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

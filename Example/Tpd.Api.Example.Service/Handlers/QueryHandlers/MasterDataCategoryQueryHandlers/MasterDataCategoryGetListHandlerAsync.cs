using System.Linq;
using System.Threading.Tasks;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueries;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers.MasterDataCategoryQueryHandlers
{
    public class MasterDataCategoryGetListHandlerAsync : QueryListHandlerAsync<MasterDataCategoryGetListQuery, DtoMasterDataCategory>
    {
        public MasterDataCategoryGetListHandlerAsync(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override async Task<IQueryable<DtoMasterDataCategory>> BuildQueryAsync(MasterDataCategoryGetListQuery query, RequestContext context)
        {
            var dataQuery = UnitOfWork.MasterDataCategory.GetQuery();

            if (!string.IsNullOrEmpty(query.Name))
            {
                dataQuery = dataQuery.Where(w => w.Name.Contains(query.Name));
            }

            if (!string.IsNullOrEmpty(query.Description))
            {
                dataQuery = dataQuery.Where(w => w.Description.Contains(query.Description));
            }

            return dataQuery.Select(s => new DtoMasterDataCategory
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });
        }
    }
}

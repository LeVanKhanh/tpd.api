using System.Collections.Generic;
using System.Linq;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueries;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers.MasterDataCategoryQueryHandlers
{
    public class MasterDataCategoryGetListHandler : QueryListHandler<MasterDataCategoryGetListQuery, DtoMasterDataCategory>
    {
        public MasterDataCategoryGetListHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override bool TryBuildQuery(MasterDataCategoryGetListQuery query, out IQueryable<DtoMasterDataCategory> queryable, out List<string> message)
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

            queryable = dataQuery.Select(s => new DtoMasterDataCategory
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });

            message = new List<string> { };
            return true;
        }
    }
}

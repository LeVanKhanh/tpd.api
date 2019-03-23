using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties;
using Tpd.Api.Example.Service.ServiceResultModels;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers.MasterDataCategoryQueryHandlers
{
    public class MasterDataCategoryGetItemHandler : QuerySingleHandler<MasterDataCategoryGetItemQuery, SrmMasterDataCategory>
    {
        public MasterDataCategoryGetItemHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override bool TryBuildQuery(MasterDataCategoryGetItemQuery query, RequestContext context,
            out IQueryable<SrmMasterDataCategory> queryable, out List<string> message)
        {
            queryable = UnitOfWork.MasterDataCategory.GetQuery()
                .Where(w => w.Id == query.Id)
                .Select(s => new SrmMasterDataCategory
                {
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    UpdatedAt = s.UpdatedAt
                });

            message = new List<string>();
            return true;
        }
    }
}

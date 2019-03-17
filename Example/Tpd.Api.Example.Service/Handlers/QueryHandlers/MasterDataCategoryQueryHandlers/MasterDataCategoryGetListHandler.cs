using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Queries.MasterDataCategoryQueties;
using Tpd.Api.Example.Service.ServiceResultModels;
using System.Linq;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers.MasterDataCategoryQueryHandlers
{
    public class MasterDataCategoryGetListHandler: QueryListHandler<MasterDataCategoryGetListQuery, SrmMasterDataCategory>
    {
        public MasterDataCategoryGetListHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override IQueryable<SrmMasterDataCategory> BuildQuery(MasterDataCategoryGetListQuery query)
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

            var dataQueryResult = dataQuery.Select(s => new SrmMasterDataCategory
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });

            return dataQueryResult;
        }
    }
}

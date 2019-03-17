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

        protected override SrmMasterDataCategory DoQuery(MasterDataCategoryGetItemQuery query)
        {
            var entity = UnitOfWork.MasterDataCategory.GetById(query.Id);
            var result = new SrmMasterDataCategory
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
            return result;
        }
    }
}

﻿using System.Collections.Generic;
using System.Linq;
using Tpd.Api.Core.DataAccess;
using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.DataAccess.UnitOfWork;

namespace Tpd.Api.Example.Service.Handlers.QueryHandlers.MasterDataCategoryQueryHandlers
{
    public class MasterDataCategoryGetItemHandler : QuerySingleHandler<QueryByIdBase, DtoMasterDataCategory>
    {
        public MasterDataCategoryGetItemHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override IQueryable<DtoMasterDataCategory> BuildQuery(QueryByIdBase query, RequestContext context)
        {
            return UnitOfWork.MasterDataCategory.GetQuery()
                .Where(w => w.Id == query.Id)
                .Select(s => new DtoMasterDataCategory
                {
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                    Name = s.Name,
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    UpdatedAt = s.UpdatedAt
                });
        }
    }
}

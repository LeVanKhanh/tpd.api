using AutoMapper;
using Tpd.Api.Database.Entities;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers.MasterDataCategoryHandlers
{
    public class MasterDataCategoryDeleteHandlerAsync : CommandDeleteHandlerAsync<MasterDataCategoryDeleteCommand, EttMasterDataCategory>
    {
        public MasterDataCategoryDeleteHandlerAsync(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {

        }
    }
}

using AutoMapper;
using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Database.Entities;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers.MasterDataCategoryHandlers
{
    public class MasterDataCategoryCreateHandler : CommandCreateHandler<MasterDataCategoryCreateCommand, bool>
    {
        public MasterDataCategoryCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {

        }

        protected override bool DoWork(MasterDataCategoryCreateCommand command)
        {
            return DoCreate<EttMasterDataCategory, DtoMasterDataCategory>(command);
        }
    }
}

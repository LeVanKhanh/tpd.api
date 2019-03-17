using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers.MasterDataCategoryHandlers
{
    public class MasterDataCategoryDeleteHandler : CommandHandler<MasterDataCategoryDeleteCommand, bool>
    {
        public MasterDataCategoryDeleteHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        protected override bool DoWork(MasterDataCategoryDeleteCommand command)
        {
            UnitOfWork.MasterDataCategory.Delete(Context, command.Model);

            return true;
        }
    }
}

using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers.MasterDataCategoryHandlers
{
    public class MasterDataCategoryUpdateHandler : CommandHandler<MasterDataCategoryUpdateCommand, bool>
    {
        public MasterDataCategoryUpdateHandler(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        protected override bool DoWork(MasterDataCategoryUpdateCommand command)
        {
            var entity = UnitOfWork.MasterDataCategory.GetById(command.Model.Id);

            entity.Name = command.Model.Name;
            entity.Description = command.Model.Description;

            UnitOfWork.MasterDataCategory.Update(Context, entity);

            return true;
        }
    }
}

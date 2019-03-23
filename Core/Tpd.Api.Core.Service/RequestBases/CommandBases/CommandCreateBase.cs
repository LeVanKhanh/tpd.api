using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public class CommandCreateBase<TModel> : CommandBase, ICommandCreateBase<TModel>
        where TModel : DtoBase
    {
        public TModel Model { get; set; }
    }
}

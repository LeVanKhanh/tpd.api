using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public class CommandUpdateBase<TModel> : CommandBase, ICommandUpdateBase<TModel>
        where TModel : DtoBase
    {
       public TModel Model { get; set; }
    }
}

using Tpd.Api.Core.DataTransferObject;

namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public interface ICommandCreateBase<TModel> : ICommandBase
        where TModel : DtoBase
    {
        TModel Model { get; set; }
    }
}

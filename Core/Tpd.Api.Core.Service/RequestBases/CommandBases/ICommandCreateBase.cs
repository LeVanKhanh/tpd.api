namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public interface ICommandCreateBase<TModel> : ICommandBase
    {
        TModel Model { get; set; }
    }
}

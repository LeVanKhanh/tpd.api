namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public class CommandCreateBase<TModel> : CommandBase,ICommandCreateBase<TModel>
    {
        public TModel Model { get; set; }
    }
}

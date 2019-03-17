using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.CommandResultBases
{
    public class CommandResultBase<T> : SingleResult<T>, ICommandResultBase<T>
         where T : new()
    {

    }
}

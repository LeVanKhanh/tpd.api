using Tpd.Api.Core.Service.RequestBases.CommandBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.CommandHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a command.
    public interface ICommandHandlerBase<TCommand>
        where TCommand : ICommandBase
    {
        //
        // Summary:
        //     This function for Handling a command.
        //     Checks is build command(s) success or not then execute the command(s)
        // Return:
        //     Tpd.Api.Core.Service.ResultBases.IResultBase<int>.
        //     With this result can be known the request is handled success or not.
        //     And the result also contain message(s) if gets error(s).
        //     System.Int: The number of state entries written to the database.
        IResultBase<int> Handle(TCommand command);
    }
}

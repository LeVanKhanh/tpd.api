using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    //
    // Summary:
    //     An abstract class provide basic functions for handling a request.
    public interface IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQueryBase
    {
        IResultBase<TResultType> Handle(TQuery query);
    }
}

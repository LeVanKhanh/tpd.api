using Tpd.Api.Core.Service.RequestBases.QueryBases;
using Tpd.Api.Core.Service.ResultBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryHandlerBase<TQuery, TResultType>
        where TQuery : IQueryBase
    {
        IResultBase<TResultType> Handle(TQuery query);
    }
}

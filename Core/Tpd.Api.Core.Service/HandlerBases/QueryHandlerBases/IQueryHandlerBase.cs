using Tpd.Api.Core.Service.RequestBases.QueryBases;

namespace Tpd.Api.Core.Service.HandlerBases.QueryHandlerBases
{
    public interface IQueryHandlerBase<in TQuery, TResultType>
        where TQuery : IQueryBase
    {
        
    }
}

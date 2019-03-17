using System.Collections;

namespace Tpd.Api.Core.Service.ResultBases
{
    public interface ICollectionResult<T> : IResultBase<T>
        where T : IEnumerable
    {
        
    }
}

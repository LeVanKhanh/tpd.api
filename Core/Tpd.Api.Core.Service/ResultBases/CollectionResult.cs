using System.Collections;

namespace Tpd.Api.Core.Service.ResultBases
{
    public class CollectionResult<T> : ResultBase<T>, ICollectionResult<T>
         where T : IEnumerable
    {
       
    }
}

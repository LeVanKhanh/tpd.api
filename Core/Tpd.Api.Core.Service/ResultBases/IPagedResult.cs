using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public interface IPagedResult<T>
    {
        List<T> Items { get; set; }
        int TotalRow { get; set; }
        int Skip { get; set; }
        int Take { get; set; }
    }
}

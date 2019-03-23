using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public class PagedResult<T> : IPagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRow { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}

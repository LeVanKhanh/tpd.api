using System.Collections.Generic;

namespace Tpd.Api.Core.Interface
{
    public class ResponseModelBase
    {
        public bool Success { get; set; }
        public List<string> Message { get; set; }
        public int Count { get; set; }
        public object Data { get; set; }
    }
}

using System.Collections.Generic;

namespace Tpd.Api.Core.Service.ResultBases
{
    public class ResultBase<T> : IResultBase<T>
    {
        public ResultBase()
        {
            ErrorMessages = new List<string>();
        }

        public bool Success { get; set; }
        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

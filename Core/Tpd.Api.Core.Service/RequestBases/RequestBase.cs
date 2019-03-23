using System.Collections.Generic;

namespace Tpd.Api.Core.Service.RequestBases
{
    public abstract class RequestBase
    {
        public RequestBase()
        {
            Context = new RequestContextBase();
        }

        public RequestContextBase Context { get; set; }
        public List<string> Messages { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}

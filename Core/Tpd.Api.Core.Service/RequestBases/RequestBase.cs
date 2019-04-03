using System.Collections.Generic;

namespace Tpd.Api.Core.Service.RequestBases
{
    public abstract class RequestBase
    {
        public RequestBase()
        {
            Context = new RequestContextBase();
            Messages = new List<string>();
        }
        //Request context.
        public RequestContextBase Context { get; set; }
        //This property will contain validation/error message(s) during handle a request.
        public List<string> Messages { get; set; }
        // Validate the request.
        public virtual bool IsValid()
        {
            return true;
        }
    }
}

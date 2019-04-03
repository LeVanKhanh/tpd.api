using System.Collections.Generic;

namespace Tpd.Api.Core.Service.RequestBases
{
    public interface IRequestBase
    {
        // Validate the request.
        bool IsValid();
        //This property will contain validation/error message(s) during handle a request.
        List<string> Messages { get; set; }
        //Request context.
        RequestContextBase Context { get; set; }
    }
}

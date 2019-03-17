using Tpd.Api.Core.Service.RequestBases;
using System.Collections.Generic;

namespace Tpd.Api.Core.Service.RequestBases
{
    public interface IRequestBase
    {
        bool IsValid();
        List<string> Messages { get; set; }
        RequestContextBase Context { get; set; }
    }
}

using System;

namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public interface ICommandDeleteBase : ICommandBase
    {
         Guid Id { get; set; }
    }
}
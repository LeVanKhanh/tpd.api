using System;

namespace Tpd.Api.Core.Service.RequestBases.CommandBases
{
    public class CommandDeleteBase : CommandBase, ICommandDeleteBase
    {
        public Guid Model { get; set; }
    }
}

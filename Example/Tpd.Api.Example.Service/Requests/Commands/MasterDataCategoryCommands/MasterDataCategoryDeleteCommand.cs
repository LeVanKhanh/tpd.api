using Tpd.Api.Core.Service.RequestBases.CommandBases;
using System;

namespace Tpd.Api.Example.Service.Requests.Commands.MasterDataCategoryCommands
{
    public class MasterDataCategoryDeleteCommand: CommandBase
    {
        public Guid Model { get; set; }
    }
}

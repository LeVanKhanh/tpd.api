using Tpd.Api.Example.DataAccess.UnitOfWork;
using Tpd.Api.Database.Entities;
using Tpd.Api.Example.Service.Requests.Commands.BleSignalCommands;
using System;
using System.Linq;

namespace Tpd.Api.Example.Service.Handlers.CommandHandlers.BleSignalHandlers
{
    public class BleSignalCreateHandler : CommandHandler<BleSignalCreateCommand, bool>
    {
        public BleSignalCreateHandler(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {

        }

        protected override bool DoWork(BleSignalCreateCommand command)
        {
            var currentDate = DateTime.UtcNow;
            var newGuid = Guid.NewGuid();
            var entities = command.Model.Select(s => new EttBleSignal
            {
                BatteryValue = s.BatteryValue,
                BeconCode = s.BeconCode,
                //CreatedAt = currentDate,
                //UpdatedAt = currentDate,
                //CreatedBy = newGuid,
                //UpdatedBy = newGuid,
                ReceivedDateUtc = currentDate,
                Frequency = s.Frequency,
                GatewayCode = s.GatewayCode,
                MFGCode = s.MFGCode,
                RhValue = s.RhValue,
                TemperatureValue = s.TemperatureValue
            });

            UnitOfWork.BleSignal.BulkAddAsync(entities);

            return true;
        }
    }
}

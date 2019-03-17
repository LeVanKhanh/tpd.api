using Tpd.Api.Core.DataTransferObject;
using System;

namespace Tpd.Api.DataTransferObject
{
    public class DtoBleSignal : DtoBase
    {
        public string MFGCode { get; set; }//
        public string GatewayCode { get; set; }// 36 - router
        public string Frequency { get; set; }
        public int BatteryValue { get; set; }
        public int TemperatureValue { get; set; }
        public string RhValue { get; set; }
        public string BeconCode { get; set; }
        public DateTime ReceivedDateUtc { get; set; }
    }
}

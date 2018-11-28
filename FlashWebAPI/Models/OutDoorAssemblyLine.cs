using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class OutDoorAssemblyLine
    {

        public int OutDoorAssemblyLineId { set; get; }
        public OutDoorAssemblyLine()
        {
            this.QualityTests = new List<QualityTest>();
        }
        
        public string Barcode { get; set; }

        public string RFIDTag { get; set; }
        public DateTime? StartingTime { get; set; }
        
        public string CompressorNumber { get; set; }
        public string MotorQRCode { get; set; }
        public string CondesorQRCode { get; set; }

        public string PCBQRCode { get; set; }
        public double? VaccumingPressure { get; set; }
        public string GasName { get; set; }
        public double? GasAmount { get; set; }
        public double? Voltage { get; set; }
        public double? Pressure { get; set; }
        public double? Current { get; set; }
        public double? Power { get; set; }
        public double? Frequancy { get; set; }
        public double? PressureAtHeatingTest { get; set; }
        public double? PressureAtPerformanceTest { get; set; }
        public double? TempratureAtHeatingTest { get; set; }
        public double? TempratureAtPerformanceTest { get; set; }
        public double? AmbientTemperature  { get; set; }
        public double? GrillTemperature { get; set; }
        public double? DeltaTemperature { get; set; }
        public DateTime? LineStartTime { get; set; }
        public DateTime? LineExitTime { get; set; }
        public ICollection<QualityTest> QualityTests { get; set; }

    }
}

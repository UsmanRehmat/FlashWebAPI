using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class InDoorAssemblyLine
    {

        public InDoorAssemblyLine()
        {
            this.QualityTests = new List<QualityTest>();
        }
       

        public int InDoorAssemblyLineId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string RFIDTag { get; set; }
        
        public string Barcode { get; set; }
        public string Model { get; set; }
        public string UnitNumber { get; set; }

        public DateTime? BarcodeScanningTime { get; set; }
        public string EvaporatorBarcode { get; set; }
        public string BlowerMotorQRCode { get; set; }
        public string ElectricalBoxQRCode { get; set; }
        public double? RPM { set; get; }
        public double? Power { get; set; }
        public double? Current { get; set; }
        public double? Voltage { get; set; }
        public double? Inductance { get; set; }
        public double? Capacitance { get; set; }
        public ICollection<QualityTest> QualityTests { get; set; }

    }
}

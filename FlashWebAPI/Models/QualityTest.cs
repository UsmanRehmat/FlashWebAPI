using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class QualityTest
    {
        [Key]
        public int QualityTestId { get; set; }
        public string Assembly { get; set; }
        public bool? CurrentTestUnit { get; set; }
        public bool? CurrentRepairingUnit { get; set; }
        public string TestName { get; set; }
        public bool? Status { get; set; }
        public DateTime? TestInTime { get; set; }
        public DateTime? TestOutTime { get; set; }
        public DateTime? RepairingInTime { get; set; }
        public DateTime? RepairingOutTime { get; set; }
        public string PreleminaryFault { get; set; }
        public string DiagnosisFault { get; set; }
        public string CorrectiveAction { get; set; }
        public string Barcode { get; set; }
        public string OperatorName { get; set; }
        public string FaultType { set; get; }
        public OutDoorAssemblyLine OutDoor { get; set; }
        public InDoorAssemblyLine InDoor { get; set; }
    }
}

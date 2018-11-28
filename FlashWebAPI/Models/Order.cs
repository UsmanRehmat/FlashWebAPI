using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class Order
    {
        [Key]
        public string OrderNumber { get; set; }
        public string Assembly { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string StartingSN { get; set; }
        public string EndingSN { get; set; }
        public DateTime? StartingDate { get; set; }
        public string PendingReason { get; set; }

    }
}

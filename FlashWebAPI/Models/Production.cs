using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class Production
    {
        [Key]
        public string OrderNo { get; set; }
        public string BarCode { get; set; }
        public string Location { get; set; }
        public string Plant { get; set; }
        public string MaterialCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string UnitModelNo { get; set; }
        public string UnitColor { get; set; }


    }
}

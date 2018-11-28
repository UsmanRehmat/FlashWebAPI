using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Models
{
    public class StationFaults
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StationName { get; set; }
        public string Assembly { get; set; }
        public string Faults { get; set; }
        public ICollection<CorrectiveAction> CorrectiveActions { get; set; }
        public StationFaults()
        {
            CorrectiveActions = new List<CorrectiveAction>();
        }

    }
}

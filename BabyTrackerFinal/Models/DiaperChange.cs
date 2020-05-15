using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTrackerFinal.Models
{
    public class DiaperChange
    {
        [Key]
        public int DiaperChangeID { get; set; }
        public int NumberOfDiaperChanges { get; set; }

        public int BabyName { get; set; }

        [ForeignKey("BabyName")]
        public BabyInfo BabyInfo { get; set; }
    }
}

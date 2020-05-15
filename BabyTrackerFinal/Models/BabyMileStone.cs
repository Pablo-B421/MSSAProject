using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTrackerFinal.Models
{
    public class BabyMileStone
    {
        [Key]
        public int MileStoneID { get; set; }
        public int Month { get; set; }
        public string Details { get; set; }

        public int BabyName { get; set; }

        [ForeignKey("BabyName")]
        public BabyInfo BabyInfo { get; set; }
    }
}

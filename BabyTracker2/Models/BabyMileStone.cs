using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker2.Models
{
    public class BabyMileStone
    {
        [Key]
        public int MileStoneID { get; set; }
        public int Month { get; set; }

        public int BabyID { get; set; }

        [ForeignKey("BabyID")]
        public BabyInfo BabyInfo { get; set; }

    }
}

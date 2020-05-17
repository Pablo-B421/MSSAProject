using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class BabyMileStone
    {
        [Key]
        public int MileStoneID { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate{ get; set; }

        public string Details { get; set; }
       

        public string BabyName { get; set; }

        [ForeignKey("BabyName")]
        public BabyInfo BabyInfo { get; set; }
    }
}

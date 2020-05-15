using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTrackerFinal.Models
{
    public class Feeding
    {
        [Key]
        public int FeedingID { get; set; }
        public int NumberOfFeedings { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FeedingTime { get; set; }

        public int BabyName { get; set; }

        [ForeignKey("BabyName")]
        public BabyInfo BabyInfo { get; set; }
    }
}

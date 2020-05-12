using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BabyTracker2.Models
{
    public class Feeding
    {
        [Key]
        public int FeedingID { get; set; }
        public int NumberOfFeedings { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FeedingTime { get; set; }

        public int BabyID { get; set; }

        [ForeignKey("BabyID")]
        public BabyInfo BabyInfo { get; set; }

    }
}

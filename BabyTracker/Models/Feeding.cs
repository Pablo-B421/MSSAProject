using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BabyTracker.Models
{
    public class Feeding
    {
        [Key]
        public int FeedingID { get; set; }
        public int NumberOfFeedings { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FeedingTime { get; set; }

        public string BabyName { get; set; }

        [ForeignKey("BabyName")]
        public BabyInfo BabyInfo { get; set; }
    }
}

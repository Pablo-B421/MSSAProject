using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class DiaperChange
    {
        [Key]
        public int NumberofDiaperChanges { get; set; }

        public int BabyID { get; set; }

        [ForeignKey("BabyID")]
        public BabyInfo BabyInfo { get; set; }
    }
}

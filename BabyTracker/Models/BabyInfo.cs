using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BabyTracker.Models
{
    public class BabyInfo
    {
        [Key]
        public int BabyID { get; set; }
        public string BabyName { get; set; }
        public char BabyGender { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int UserID { get; set; }
        public Users Users { get; set; }


    }
}

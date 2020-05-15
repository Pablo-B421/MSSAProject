using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BabyTrackerFinal.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }

        public List<BabyInfo> BabyInfos { get; set; }
    }
}

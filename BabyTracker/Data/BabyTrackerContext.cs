using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BabyTracker.Models;

namespace BabyTracker.Data
{
    public class BabyTrackerContext :DbContext
    {
        public BabyTrackerContext(DbContextOptions<BabyTrackerContext> options)
          : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<BabyTracker.Models.BabyInfo> BabyInfo { get; set; }
        public DbSet<BabyTracker.Models.BabyMileStone> BabyMileStone { get; set; }
        public DbSet<BabyTracker.Models.DiaperChange> DiaperChange { get; set; }
        public DbSet<BabyTracker.Models.Feeding> Feeding { get; set; }
    }
}

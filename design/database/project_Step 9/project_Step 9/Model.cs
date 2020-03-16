using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BabyTracker : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Baby> Baby { get; set; }

        public DbSet<Feedings> Feedings { get; set; }
        public DbSet<DiaperChanges> DiaperChanges { get; set; }
        public DbSet<BabyMileStones> BabyMileStones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=blogging.db");
    }

    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<Baby> Baby { get; } = new List<Baby>();
    }

    public class Baby
    {
        public int BabyId { get; set; }
        public string BabyName { get; set; }
        public string BabyGender { get; set; }
        public int BabyBirthDate { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }

        public List<Feedings> Feedings { get; } = new List<Feedings>();
        public List<DiaperChanges> DiaperChanges { get; } = new List<DiaperChanges>();
        public List<BabyMileStones> BabyMileStones { get; } = new List<BabyMileStones>();


    }
    public class Feedings
    {
        public int NumberofFeedings { get; set; }
        public int FeedingTime { get; set; }

        public int BabyID { get; set; }
        public Baby Baby { get; set; }
    }

    public class DiaperChanges
    {
        public int NumberofDiaperChanges { get; set; }
        public int BabyID { get; set; }
        public Baby Baby { get; set; }
    }
    public class BabyMileStones
    {
        public int MileStonesID { get; set; }
        public int Month { get; set; }
        
        public int BabyID { get; set; }
        public Baby Baby { get; set; }
    }
}
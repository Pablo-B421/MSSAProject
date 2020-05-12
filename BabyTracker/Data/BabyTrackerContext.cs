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
        public BabyTrackerContext(DbContextOptions<BabyTrackerContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; } 
    }
}

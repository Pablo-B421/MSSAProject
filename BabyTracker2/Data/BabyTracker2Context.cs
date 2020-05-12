using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BabyTracker2.Models;

namespace BabyTracker2.Data
{
    public class BabyTracker2Context : DbContext
    {
        public BabyTracker2Context(DbContextOptions<BabyTracker2Context> options): base(options)
        {
        }
        public DbSet<Users> Users{ get; set; }
    }
}

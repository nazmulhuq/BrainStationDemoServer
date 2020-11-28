using BrainStationDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStationDemo.Data
{
    public class BrainStationDemoContext : DbContext
    {
        public BrainStationDemoContext(DbContextOptions options): base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }  


    }
}

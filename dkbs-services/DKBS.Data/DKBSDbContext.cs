using DKBS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Data
{
   public class DKBSDbContext :DbContext
    {
        public DKBSDbContext(DbContextOptions<DKBSDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace BinbinJobSearch.Entities
{
    public class JobSearchDataContext : DbContext
    {
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<Posting> Posting { get; set; }
         
       
    }
}

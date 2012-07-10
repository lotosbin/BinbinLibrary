using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BinbinAccount.Entities
{
    public class ApplicationServices:DbContext
    {
        public DbSet<AspnetUser> User { get; set; }
    }
}

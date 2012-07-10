using System.Data.Entity;

namespace BinbinProductSearch.Entities
{
    public class BinbinProductSearchDataContext:DbContext
    {
        public DbSet<Product> Product { get; set; }
    }
}
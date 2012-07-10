using System.Data.Entity;

namespace BinbinJobFeed.Entities
{
    public class BinbinJobFeedDataContext:DbContext
    {
        public DbSet<Posting> Posting { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace PFLogistcs.Context
{
    public class PFLogisticsDbContext : DbContext
    {
        public PFLogisticsDbContext(DbContextOptions<PFLogisticsDbContext> options) : base(options) { }
    }
}
using Microsoft.EntityFrameworkCore;
using Sales_Tracking.API.Models.Domains;

namespace Sales_Tracking.API.Data
{
    public class TrackerDBContext : DbContext
    {
        public TrackerDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FormManagement> FormManagements { get; set; }
        public DbSet<Tansaction> Tansactions { get; set; }
    }
}

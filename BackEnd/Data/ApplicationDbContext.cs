using Microsoft.EntityFrameworkCore;
using AnelPowerAPI.Models;

namespace AnelPowerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Anel> Anéis { get; set; }
    }
}

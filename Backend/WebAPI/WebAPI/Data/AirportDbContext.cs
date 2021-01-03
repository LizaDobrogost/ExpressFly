using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AirportDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public AirportDbContext(DbContextOptions<AirportDbContext> options) :
            base(options)
        {}
    }
}
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class ApiContext : DbContext 
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Led> Leds { get; set; }

    }
}

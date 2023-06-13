using Formula_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula_Api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
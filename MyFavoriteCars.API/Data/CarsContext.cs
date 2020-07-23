using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> opt) : base(opt) { }
        // DbSet<obj> DatabaseTable
        public DbSet<Car> Cars { get; set; }
    }
}
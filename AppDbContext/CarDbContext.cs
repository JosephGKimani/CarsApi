using CarApi.Models;
using Microsoft.EntityFrameworkCore;
namespace CarApi.AppDbContext
{
    public class CarDbContext: DbContext
    {
        public CarDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
    }
}

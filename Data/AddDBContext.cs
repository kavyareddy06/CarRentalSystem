using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Data
{
    public class AddDBContext:DbContext
    {
       public AddDBContext(DbContextOptions<AddDBContext> options):base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

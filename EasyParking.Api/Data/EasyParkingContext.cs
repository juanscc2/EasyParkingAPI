using EasyParking.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyParking.Api.Data
{
    public class EasyParkingContext:DbContext
    {
        public EasyParkingContext(DbContextOptions<EasyParkingContext> options)
            : base(options) { 

        }
        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Helmet> Helmet { get; set;}

        public DbSet<Bill> Bill { get; set; }

        public DbSet<Vehicle> Vehicle  { get; set; }
    }
}

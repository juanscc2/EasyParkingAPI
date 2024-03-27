using EasyParking.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyParking.Api.Data
{
    public class EasyParkingContext:DbContext
    {
        public EasyParkingContext(DbContextOptions<EasyParkingContext> options)
            : base(options) { 

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Helmet> Helmets { get; set;}

        public DbSet<Bill> bills { get; set; }

        public DbSet<Vehicle> vehicles { get; set; }
    }
}

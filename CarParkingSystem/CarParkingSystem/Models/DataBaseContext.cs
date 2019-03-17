using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CarParkingSystem.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext()
        {

        }


        public DbSet<ParkingSpace> parkingSpace { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
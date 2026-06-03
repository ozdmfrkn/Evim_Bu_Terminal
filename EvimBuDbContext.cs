using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim_Bu
{
    public class EvimBuDbContext : DbContext
    {
        public EvimBuDbContext() : base("name=EvimBuDbContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable("Table_Booking");
            modelBuilder.Entity<Property>().ToTable("Table_Property");
            modelBuilder.Entity<Category>().ToTable("Table_Category");
            modelBuilder.Entity<User>().ToTable("Table_User");

            base.OnModelCreating(modelBuilder);
        }
    }
}
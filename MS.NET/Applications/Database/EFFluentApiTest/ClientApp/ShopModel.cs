using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ClientApp
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }
    }

    public class Customer
    {
        public string CustomerId { get; set; }

        public decimal Credit { get; set; }

        //navigation property(virtual) with automatic(lazy) loading
        public virtual ICollection<OrderDetail> Orders { get; set; }

    }

    //see <connectionStrings> in App.config
    public class ShopModel : DbContext
    {
 
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetail")
                .Property(p => p.Id)
                .HasColumnName("OrderNo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ServerApp.Models
{
    [Table("OrderDetail")]
    public class Order
    {
        [Column("OrderNo")]
        public int Id { get; set; }

        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}")]
        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        [Column("ProductNo")]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }

    [Table("Product")]
    public class Product
    {
        [Column("ProductNo")]
        [DisplayName("Product No")]
        public int Id { get; set; }

        [DisplayName("Unit Price")]
        public decimal Price { get; set; }

        [DisplayName("Current Stock")]
        [Range(5, 50)]
        public int Stock { get; set; }

        //non-virtual navigation property will require explicit loading
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public class ShopModel : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

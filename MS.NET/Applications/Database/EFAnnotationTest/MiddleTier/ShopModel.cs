using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiddleTier
{
    public class Counter
    {
        public string Id { get; set; }

        public int CurrentValue { get; set; }
    }

    [Table("OrderDetail")]
    public class OrderEntry
    {
        [Column("OrderNo")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Today;

        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }
    }

    public class ShopModel : DbContext
    {
        public ShopModel() : base("Data Source=.;Initial Catalog=Shop;Integrated Security=True")
        {

        }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<OrderEntry> Orders { get; set; }
    }
}

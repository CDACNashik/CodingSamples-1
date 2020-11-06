using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ServerApp.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("ProductNo")]
        public int Id { get; set; }

        public decimal Price { get; set; }

        [Range(5, 50)]
        public int Stock { get; set; }
    }

    public class ShopModel : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

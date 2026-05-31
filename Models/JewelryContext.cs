using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryContext : DbContext
    {
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
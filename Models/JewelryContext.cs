using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryContext : DbContext
    {
        public JewelryContext() : base("JewelryContext") { }

        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
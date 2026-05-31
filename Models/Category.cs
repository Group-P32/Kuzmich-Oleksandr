using System.Collections.Generic;

namespace JewelryStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Назва категорії
        public string Description { get; set; } // Опис

        public ICollection<Jewelry> Jewelries { get; set; }
        public Category()
        {
            Jewelries = new List<Jewelry>();
        }
    }
}
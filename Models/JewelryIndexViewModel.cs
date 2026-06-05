using System.Collections.Generic;

namespace JewelryStore.Models
{
    public class JewelryIndexViewModel
    {
        public IEnumerable<Jewelry> Jewelries { get; set; }
        public PageInfo PageInfo { get; set; }

        // Зберігаємо параметри фільтрації для пагінації
        public int? CategoryId { get; set; }
        public string Material { get; set; }
    }
}
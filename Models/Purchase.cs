using System;

namespace JewelryStore.Models
{
    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }

        // Ім'я та прізвище покупця
        public string Person { get; set; }

        // Адреса покупця
        public string Address { get; set; }

        // ID прикраси
        public int JewelryId { get; set; }

        // Дата покупки
        public DateTime Date { get; set; }
    }
}
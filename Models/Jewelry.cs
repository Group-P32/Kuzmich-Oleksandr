using System;

namespace JewelryStore.Models
{
    public class Jewelry
    {
        // ID товару
        public int Id { get; set; }

        // Назва прикраси
        public string Name { get; set; }

        // Тип (каблучка, браслет, намисто...)
        public string Type { get; set; }

        // Матеріал (золото, срібло...)
        public string Material { get; set; }

        // Вага в грамах
        public double Weight { get; set; }

        // Ціна в гривнях
        public decimal Price { get; set; }
    }
}
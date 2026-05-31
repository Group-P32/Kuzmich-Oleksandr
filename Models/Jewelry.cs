using System.ComponentModel.DataAnnotations;

namespace JewelryStore.Models
{
    public class Jewelry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }        // Назва прикраси

        [Required]
        public string Material { get; set; }    // Матеріал

        public decimal Price { get; set; }      // Ціна

        public int? CategoryId { get; set; }    // Зовнішній ключ
        public Category Category { get; set; }  // Навігаційна властивість
    }
}
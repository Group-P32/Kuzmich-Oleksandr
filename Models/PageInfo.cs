using System;

namespace JewelryStore.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; }  // номер поточної сторінки
        public int PageSize { get; set; }    // кількість об'єктів на сторінці
        public int TotalItems { get; set; }  // загальна кількість об'єктів

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
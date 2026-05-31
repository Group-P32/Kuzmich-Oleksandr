using System.Collections.Generic;
using System.Web.Mvc;

namespace JewelryStore.Models
{
    public class JewelryListViewModel
    {
        public IEnumerable<Jewelry> Jewelries { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Materials { get; set; }
    }
}
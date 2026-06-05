using System.Collections.Generic;
using System.Data.Entity;
namespace JewelryStore.Models
{
    public class JewelryDbInitializer : DropCreateDatabaseAlways<JewelryContext>
    {
        protected override void Seed(JewelryContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Каблучки",  Description = "Золоті та срібні каблучки" },
                new Category { Name = "Намисто",   Description = "Намисто з коштовним камінням" },
                new Category { Name = "Браслети",  Description = "Браслети з різних матеріалів" },
                new Category { Name = "Сережки",   Description = "Сережки різних форм та розмірів" },
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var jewelries = new List<Jewelry>
            {
                new Jewelry { Name = "Золота каблучка",         Material = "Золото",  Price = 5500m,  CategoryId = 1 },
                new Jewelry { Name = "Срібна каблучка",         Material = "Срібло",  Price = 2200m,  CategoryId = 1 },
                new Jewelry { Name = "Каблучка з діамантом",    Material = "Золото",  Price = 9800m,  CategoryId = 1 },
                new Jewelry { Name = "Каблучка з рубіном",      Material = "Золото",  Price = 7500m,  CategoryId = 1 },
                new Jewelry { Name = "Срібне намисто",          Material = "Срібло",  Price = 3200m,  CategoryId = 2 },
                new Jewelry { Name = "Золоте намисто",          Material = "Золото",  Price = 8900m,  CategoryId = 2 },
                new Jewelry { Name = "Намисто з перлами",       Material = "Перли",   Price = 4100m,  CategoryId = 2 },
                new Jewelry { Name = "Намисто з сапфіром",      Material = "Срібло",  Price = 5600m,  CategoryId = 2 },
                new Jewelry { Name = "Діамантовий браслет",     Material = "Золото",  Price = 12000m, CategoryId = 3 },
                new Jewelry { Name = "Срібний браслет",         Material = "Срібло",  Price = 1800m,  CategoryId = 3 },
                new Jewelry { Name = "Браслет з перлами",       Material = "Перли",   Price = 3300m,  CategoryId = 3 },
                new Jewelry { Name = "Золотий браслет",         Material = "Золото",  Price = 6700m,  CategoryId = 3 },
                new Jewelry { Name = "Перлинні сережки",        Material = "Перли",   Price = 2800m,  CategoryId = 4 },
                new Jewelry { Name = "Золоті сережки",          Material = "Золото",  Price = 4500m,  CategoryId = 4 },
                new Jewelry { Name = "Срібні сережки",          Material = "Срібло",  Price = 1500m,  CategoryId = 4 },
                new Jewelry { Name = "Сережки з діамантом",     Material = "Золото",  Price = 11000m, CategoryId = 4 },
            };
            jewelries.ForEach(j => context.Jewelries.Add(j));
            context.SaveChanges();
        }
    }
}
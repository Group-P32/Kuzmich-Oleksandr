using System.Collections.Generic;
using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryDbInitializer : DropCreateDatabaseAlways<JewelryContext>
    {
        protected override void Seed(JewelryContext context)
        {
            // Категорії
            var categories = new List<Category>
            {
                new Category { Name = "Каблучки",   Description = "Золоті та срібні каблучки" },
                new Category { Name = "Намисто",    Description = "Намисто з коштовним камінням" },
                new Category { Name = "Браслети",   Description = "Браслети з різних матеріалів" },
                new Category { Name = "Сережки",    Description = "Сережки різних форм та розмірів" },
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            // Прикраси з категоріями
            var jewelries = new List<Jewelry>
            {
                new Jewelry { Name = "Золота каблучка",       Material = "Золото",   Price = 5500m,  CategoryId = 1 },
                new Jewelry { Name = "Срібне намисто",        Material = "Срібло",   Price = 3200m,  CategoryId = 2 },
                new Jewelry { Name = "Діамантовий браслет",   Material = "Золото",   Price = 12000m, CategoryId = 3 },
                new Jewelry { Name = "Перлинні сережки",      Material = "Перли",    Price = 2800m,  CategoryId = 4 },
            };
            jewelries.ForEach(j => context.Jewelries.Add(j));
            context.SaveChanges();
        }
    }
}
using System.Data.Entity;

namespace JewelryStore.Models
{
    public class JewelryDbInitializer : DropCreateDatabaseAlways<JewelryContext>
    {
        protected override void Seed(JewelryContext db)
        {
            db.Jewelries.Add(new Jewelry { Name = "Каблучка з діамантом", Type = "Каблучка", Material = "Золото", Weight = 3.5, Price = 15000 });
            db.Jewelries.Add(new Jewelry { Name = "Золотий браслет", Type = "Браслет", Material = "Золото", Weight = 10.2, Price = 8500 });
            db.Jewelries.Add(new Jewelry { Name = "Срібне намисто", Type = "Намисто", Material = "Срібло", Weight = 15.0, Price = 3200 });
            db.Jewelries.Add(new Jewelry { Name = "Сережки з рубіном", Type = "Сережки", Material = "Золото", Weight = 4.1, Price = 12000 });
            base.Seed(db);
        }
    }
}
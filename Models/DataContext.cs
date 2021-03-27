using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class DataContext:DbContext
    {
        public DbSet<ObjectOfRealEstate> ObjectOfRealEstates { get; set; }

    }

    public class ObjectOfRealEstatesDbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            db.ObjectOfRealEstates.Add(new ObjectOfRealEstate { Id= Guid.NewGuid() ,Name = "Дом", Description = "Красивый", Price = 10000000 });
            db.ObjectOfRealEstates.Add(new ObjectOfRealEstate { Id = Guid.NewGuid(), Name = "Гараж", Description = "Вместительный", Price = 50000 });

            base.Seed(db);
        }
    }
}
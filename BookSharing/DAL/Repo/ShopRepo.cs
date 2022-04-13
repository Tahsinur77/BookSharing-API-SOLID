using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ShopRepo : IRepository<Shop, int>
    {
        private BookSharingContext db;
        public ShopRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(Shop obj)
        {
            db.Shops.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.Shops.FirstOrDefault(x => x.Id == id);
            db.Shops.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(Shop obj)
        {
            var old = db.Shops.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Shop Get(int id)
        {
            return db.Shops.FirstOrDefault(x => x.Id == id);
        }

        public List<Shop> Get()
        {
            return db.Shops.ToList();
        }
    }
}

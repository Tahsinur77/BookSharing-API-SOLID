using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SellRepo : IRepository<Sell, int>
    {
        private BookSharingContext db;
        public SellRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(Sell obj)
        {
            db.Sells.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var od = db.Sells.FirstOrDefault(x => x.Id == id);
            db.Sells.Remove(od);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(Sell obj)
        {
            var oe = db.Sells.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(oe).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Sell Get(int id)
        {
            return db.Sells.FirstOrDefault(x => x.Id == id);
        }

        public List<Sell> Get()
        {
            return db.Sells.ToList();
        }
    }
}

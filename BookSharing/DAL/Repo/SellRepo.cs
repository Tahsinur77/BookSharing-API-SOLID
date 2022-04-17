using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SellRepo : IRepository<Sell, int>,ISearch<Sell>
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
        public List<Sell> Search(Dictionary<string, dynamic> search)
        {
            // Search by OrderId or Status 
            if (search.Count == 1)
            {
                string key = Convert.ToString(search.ElementAt(0).Key);
               
                var list = new List<Sell>();
                if (key == "OrderId")
                {
                    int value = Convert.ToInt32(search.ElementAt(0).Value);
                    list = (from c in db.Sells
                            where c.OrderId.Equals(value)
                            select c).ToList();
                }
                else if (key == "Status")
                {
                    string value = Convert.ToString(search.ElementAt(0).Value);
                    list = (from c in db.Sells
                            where c.Status.Equals(value)
                            select c).ToList();
                }
                return list;
            }
            //Search by OrderId and Status both
            else if (search.Count == 2)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                int value1 = Convert.ToInt32(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);

                var list = new List<Sell>();
                if (key1 == "OrderId" && key2 == "Status")
                {
                    list = (from c in db.Sells
                            where c.OrderId.Equals(value1) &&
                            c.Status.Equals(value2)
                            select c).ToList();
                }
                return list;
            }
      
            else
                return null;
        }
        
    }
}

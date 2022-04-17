using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class OrderRepo : IRepository<Order, int>
    {
        private BookSharingContext db;
        public OrderRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
            
        }

        public bool Delete(int id)
        {
            var od = db.Orders.FirstOrDefault(x => x.Id == id);
            db.Orders.Remove(od);

            if (db.SaveChanges() != 0) return true;
            return false;
            
        }

        public bool Edit(Order obj)
        {
            var oe = db.Orders.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(oe).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;

        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }
    }
}

using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class OrderDetailsRepo : IRepository<OrderDetails, int>
    {
        private BookSharingContext db;
        public OrderDetailsRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(OrderDetails obj)
        {
            db.OrderDetails.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;

        }

        public bool Delete(int id)
        {
            var odd = db.OrderDetails.FirstOrDefault(x => x.Id == id);
            db.OrderDetails.Remove(odd);

            if (db.SaveChanges() != 0) return true;
            return false;

        }

        public bool Edit(OrderDetails obj)
        {
            var ode = db.OrderDetails.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(ode).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;

        }

        public OrderDetails Get(int id)
        {
            return db.OrderDetails.FirstOrDefault(x => x.Id == id);
        }

        public List<OrderDetails> Get()
        {
            return db.OrderDetails.ToList();
        }
    }
}

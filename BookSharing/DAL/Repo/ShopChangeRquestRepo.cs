using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ShopChangeRquestRepo : IRepository<ShopChangeRequest, int>
    {
        private BookSharingContext db;
        public ShopChangeRquestRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(ShopChangeRequest obj)
        {
            db.ShopChangeRequests.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.ShopChangeRequests.FirstOrDefault(x => x.Id == id);
            db.ShopChangeRequests.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(ShopChangeRequest obj)
        {
            var old = db.ShopChangeRequests.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public ShopChangeRequest Get(int id)
        {
            return db.ShopChangeRequests.FirstOrDefault(x => x.Id == id);
        }

        public List<ShopChangeRequest> Get()
        {
            return db.ShopChangeRequests.ToList();
        }
    }
}

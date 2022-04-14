using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SellerDetailsRepo : IRepository<SellerDetails, int>
    {
        private BookSharingContext db;
        public SellerDetailsRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(SellerDetails obj)
        {
            db.SellerDetails.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.SellerDetails.FirstOrDefault(x => x.Id == id);
            db.SellerDetails.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(SellerDetails obj)
        {
            var old = db.SellerDetails.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public SellerDetails Get(int id)
        {
            return db.SellerDetails.FirstOrDefault(x => x.Id == id);
        }

        public List<SellerDetails> Get()
        {
            return db.SellerDetails.ToList();
        }
    }
}

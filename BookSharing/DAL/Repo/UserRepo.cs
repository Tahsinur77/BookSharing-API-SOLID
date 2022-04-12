using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepository<User, int>
    {
        private BookSharingContext db;
        public UserRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.Users.FirstOrDefault(x => x.Id == id);
            db.Users.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(User obj)
        {
            var old = db.Users.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }
    }
}

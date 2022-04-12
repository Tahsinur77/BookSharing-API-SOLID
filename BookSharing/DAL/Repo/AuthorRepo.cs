using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AuthorRepo : IRepository<Author, int>
    {
        private BookSharingContext db;
        public AuthorRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(Author obj)
        {
            db.Authors.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.Authors.FirstOrDefault(x => x.Id == id);
            db.Authors.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(Author obj)
        {
            var old = db.Authors.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Author Get(int id)
        {
            var result = db.Authors.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<Author> Get()
        {
            return db.Authors.ToList();
        }
    }
}

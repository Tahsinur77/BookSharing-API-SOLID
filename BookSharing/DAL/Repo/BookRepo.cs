using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BookRepo : IRepository<Book, int>
    {
        private BookSharingContext db;
        public BookRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(Book obj)
        {
            db.Books.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.Books.FirstOrDefault(x => x.Id == id);
            db.Books.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(Book obj)
        {
            var old = db.Books.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public Book Get(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }
    }
}

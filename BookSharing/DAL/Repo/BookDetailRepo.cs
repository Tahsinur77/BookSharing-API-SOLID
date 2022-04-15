using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BookDetailRepo : IRepository<BookDetails, int>
    {
        private BookSharingContext db;
        public BookDetailRepo(BookSharingContext db)
        {
            this.db = db;
        }
        public bool Add(BookDetails obj)
        {
            db.BookDetails.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var n = db.BookDetails.FirstOrDefault(x => x.Id == id);
            db.BookDetails.Remove(n);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(BookDetails obj)
        {
            var old = db.BookDetails.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(old).CurrentValues.SetValues(obj);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public BookDetails Get(int id)
        {
            var result = db.BookDetails.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public List<BookDetails> Get()
        {
            return db.BookDetails.ToList();
        }
    }
}

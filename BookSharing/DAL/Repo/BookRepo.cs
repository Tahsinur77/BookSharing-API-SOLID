
using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BookRepo : IRepository<Book, int>, ISearch<Book>
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
            var bd = db.Books.FirstOrDefault(x => x.Id == id);
            db.Books.Remove(bd);

            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Edit(Book obj)
        {
            var be = db.Books.FirstOrDefault(x => x.Id == obj.Id);
            db.Entry(be).CurrentValues.SetValues(obj);

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

        public List<Book> Search(Dictionary<string, dynamic> search)
        {
            //Search by Book Name or Book Category or Author Name
            if (search.Count == 1)
            {
                string key = Convert.ToString(search.ElementAt(0).Key);
                string value = Convert.ToString(search.ElementAt(0).Value);

                var list = new List<Book>();
                if (key == "Name")
                {
                    list = (from c in db.Books
                            where c.Name.Equals(value)
                            select c).ToList();
                }
                else if (key == "AuthorName")
                {
                    list = (from c in db.Books
                            where c.Author.Name.Equals(value)
                            select c).ToList();
                }
                else if (key == "Category")
                {
                    list = (from c in db.Books
                            where c.Category.Equals(value)
                            select c).ToList();
                }
                return list;
            }

            //Search By 2 Categories
            else if (search.Count == 2)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                string value1 = Convert.ToString(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);

                var list = new List<Book>();
                if (key1 == "Name" && key2 == "Category")
                {
                    list = (from c in db.Books
                            where c.Name.Equals(value1) &&
                            c.Category.Equals(value2)
                            select c).ToList();
                }
                else if (key1 == "Name" && key2 == "AuthorName")
                {
                    list = (from c in db.Books
                            where c.Name.Equals(value1) &&
                            c.Author.Name.Equals(value2)
                            select c).ToList();
                }
                else if (key1 == "AuthorName" && key2 == "Category")
                {
                    list = (from c in db.Books
                            where c.Author.Name.Equals(value1) &&
                            c.Category.Equals(value2)
                            select c).ToList();
                }
                return list;
            }

            // Search by All, Book Name & Book Category & Author Name
            else if (search.Count == 2)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                string value1 = Convert.ToString(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);
                string key3 = Convert.ToString(search.ElementAt(2).Key);
                string value3 = Convert.ToString(search.ElementAt(2).Value);

                var list = new List<Book>();
                if (key1 == "Name" && key2 == "Category" && key3 == "AuthorName")
                {
                    list = (from c in db.Books
                            where c.Name.Equals(value1) &&
                            c.Category.Equals(value2) &&
                            c.Author.Name.Equals(value3)
                            select c).ToList();
                }
                return list;
            }
            else
                return null;
        }
    }
}

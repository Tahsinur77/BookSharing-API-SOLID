using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AuthorRepo : IRepository<Author, int>, ISearch<Author>
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

        public List<Author> Search(Dictionary<string, dynamic> search)
        {
            if (search.Count == 1)
            {
                string key = Convert.ToString(search.ElementAt(0).Key);
                

                var list = new List<Author>();
                if (key == "Name")
                {
                    string value = Convert.ToString(search.ElementAt(0).Value);
                    list = (from c in db.Authors
                            where c.Name.Equals(value)
                            select c).ToList();
                }
                else if (key == "Id")
                {
                    int value = Convert.ToInt32(search.ElementAt(0).Value);
                    list = (from c in db.Authors
                            where c.Id.Equals(value)
                            select c).ToList();
                }
                return list;
            }
            else if (search.Count == 2)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                int value1 = Convert.ToInt32(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);

                var list = new List<Author>();

                if (key1 == "Id" && key2 == "Name")
                {
                    list = (from c in db.Authors
                            where c.Id.Equals(value1) &&
                            c.Name.Equals(value2)
                            select c).ToList();
                }
                return list;
            }
            else
                return null;
        }
    }
}

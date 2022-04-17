using DAL.Codefirst.Database;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepository<User, int>, ISearch<User>
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

        public List<User> Search(Dictionary<string, dynamic> search)
        {
            if (search.Count == 1)
            {
                string key = Convert.ToString(search.ElementAt(0).Key);
                string value = Convert.ToString(search.ElementAt(0).Value);

                var list = new List<User>();
                if (key == "Name")
                {
                    list = (from c in db.Users
                            where c.Name.Equals(value)
                            select c).ToList();
                }
                else if (key == "Email")
                {
                    list = (from c in db.Users
                            where c.Email.Equals(value)
                            select c).ToList();
                }
                else if (key == "Phone")
                {
                    list = (from c in db.Users
                            where c.Phone.Equals(value)
                            select c).ToList();
                }
                return list;
            }
            else if (search.Count == 2)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                string value1 = Convert.ToString(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);

                var list = new List<User>();
                if (key1 == "Name" && key2 == "Email")
                {
                    list = (from c in db.Users
                            where c.Name.Equals(value1) &&
                            c.Email.Equals(value2)
                            select c).ToList();
                }
                else if (key1 == "Name" && key2 == "Phone")
                {
                    list = (from c in db.Users
                            where c.Name.Equals(value1) &&
                            c.Phone.Equals(value2)
                            select c).ToList();
                }
                else if (key1 == "Email" && key2 == "Phone")
                {
                    list = (from c in db.Users
                            where c.Email.Equals(value1) &&
                            c.Phone.Equals(value2)
                            select c).ToList();
                }
                return list;
            }
            else if (search.Count == 3)
            {
                string key1 = Convert.ToString(search.ElementAt(0).Key);
                string value1 = Convert.ToString(search.ElementAt(0).Value);
                string key2 = Convert.ToString(search.ElementAt(1).Key);
                string value2 = Convert.ToString(search.ElementAt(1).Value);
                string key3 = Convert.ToString(search.ElementAt(2).Key);
                string value3 = Convert.ToString(search.ElementAt(2).Value);

                var list = new List<User>();
                if (key1 == "Name" && key2 == "Email" && key3 == "Phone")
                {
                    list = (from c in db.Users
                            where c.Name.Equals(value1) &&
                            c.Email.Equals(value2) &&
                            c.Phone.Equals(value3)
                            select c).ToList();
                }
                return list;
            }
            else
                return null;
        }
    }
}
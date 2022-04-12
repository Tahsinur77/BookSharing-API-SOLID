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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Author obj)
        {
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Author> Get()
        {
            throw new NotImplementedException();
        }
    }
}

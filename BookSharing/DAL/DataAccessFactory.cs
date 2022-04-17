using DAL.Codefirst.Database;
using DAL.Interface;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static BookSharingContext db = new BookSharingContext();
        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<Author, int> AuthorDataAccess()
        {
            return new AuthorRepo(db);
        }
        public static IRepository<Book, int> BookDataAccess()
        {
            return new BookRepo(db);
        }
        public static IRepository<Book, int> BookDetailDataAccess()
        {
            return new BookRepo(db);
        }
        public static IRepository<Order, int> OrderDataAccess()
        {
            return new OrderRepo(db);
        }
        public static IRepository<OrderDetails, int> OrderDetailsDataAccess()
        {
            return new OrderDetailsRepo(db);
        }

        public static IRepository<Shop, int> ShopDataAccess()
        {
            return new ShopRepo(db);
        }

        public static IRepository<SellerDetails, int> SellerDetailsDataAccess()
        {
            return new SellerDetailsRepo(db);
        }
        public static IRepository<ShopChangeRequest, int> ShopChangeRequestDataAccess()
        {
            return new ShopChangeRquestRepo(db);
        }
        public static IRepository<Sell, int> SellDataAccess()
        {
            return new SellRepo(db);
        }
        public static ISearch<User> UserDataSearch()
        {
            return new UserRepo(db);
        }
        public static ISearch<Sell> SellDataSearch()
        {
            return new SellRepo(db);
        }
        public static ISearch<Book> BookSearch()
        {
            return new BookRepo(db);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Codefirst.Database
{
    public class BookSharingContext:DbContext
    {
        public BookSharingContext() : base("Name=BookSharingDb")
        {

        }
        public DbSet<User> Users { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<Book> Books { set; get; }
        public DbSet<Shop> Shops { set; get; }
        public DbSet<BookDetails> BookDetails { set; get; }
        public DbSet<ShopChangeRequest> ShopChangeRequests { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetails> OrderDetails { set; get; }
        public DbSet<Sell> Sells { set; get; }
        public DbSet<SellerDetails> SellerDetails { set; get; }
        public DbSet<TokenAccess> TokenAccesses { set; get; }
    }
}

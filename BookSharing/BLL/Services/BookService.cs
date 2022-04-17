using AutoMapper;
using DAL;
using DAL.Codefirst.Database;
using ELL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService
    {
        public static BookModel Get(int userId)
        {
            var book = DataAccessFactory.BookDataAccess().Get(userId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookModel>());
            var mapper = new Mapper(config);
            var bookModel = mapper.Map<BookModel>(book);

            return bookModel;
        }
        public static List<BookModel> Get()
        {
            var bookList = DataAccessFactory.BookDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookModel>());
            var mapper = new Mapper(config);
            var bookModelList = mapper.Map<List<BookModel>>(bookList);

            return bookModelList;

        }
        public static bool Add(BookModel bookModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookModel, Book>());
            var mapper = new Mapper(config);
            var book = mapper.Map<Book>(bookModel);

            var check = DataAccessFactory.BookDataAccess().Add(book);
            return check;
        }

        public static bool Edit(BookModel bookModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookModel, Book>());
            var mapper = new Mapper(config);
            var book = mapper.Map<Book>(bookModel);

            var flag = DataAccessFactory.BookDataAccess().Edit(book);
            return flag;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.BookDataAccess().Delete(id);
            return flag;
        }
        public static List<BookModel> SearchBook(SearchModel search)
        {

            var bookList = DataAccessFactory.BookSearch().Search(search.Search);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookModel>());
            var mapper = new Mapper(config);
            var bookModel = mapper.Map<List<BookModel>>(bookList);

            return bookModel;
        }
    }
}

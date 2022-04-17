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
    public class OrderDetailsService
    {
        public static OrderDetailsModel Get(int orderId)
        {
            var order = DataAccessFactory.OrderDetailsDataAccess().Get(orderId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetails, OrderDetailsModel>());
            var mapper = new Mapper(config);
            var OrderDetailsModel = mapper.Map<OrderDetailsModel>(order);
            return OrderDetailsModel;
        }

        public static List<OrderDetailsModel> Get()
        {
            var orderDetailsList = DataAccessFactory.OrderDetailsDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetails, OrderDetailsModel>());
            var mapper = new Mapper(config);
            var orderDetailsModelList = mapper.Map<List<OrderDetailsModel>>(orderDetailsList);

            return orderDetailsModelList;

        }

        public static bool Add(OrderDetailsModel orderDetailsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetailsModel, OrderDetails>());
            var mapper = new Mapper(config);
            var order = mapper.Map<OrderDetails>(orderDetailsModel);

            var check = DataAccessFactory.OrderDetailsDataAccess().Add(order);
            return check;
        }

        public static bool Edit(OrderDetailsModel orderDetailsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDetailsModel, OrderDetails>());
            var mapper = new Mapper(config);
            var order = mapper.Map<OrderDetails>(orderDetailsModel);

            var flag = DataAccessFactory.OrderDetailsDataAccess().Edit(order);
            return flag;
        }

        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.OrderDetailsDataAccess().Delete(id);
            return flag;
        }

        public static List<BookModel> GetTop()
        {
            var list = DataAccessFactory.TopSellingReport().GetTop();

            Dictionary<int, int> calculation = new Dictionary<int, int>();
            foreach(var cal in list)
            {
                int key = cal.BookId;
                if (calculation.ContainsKey(key))
                {
                    calculation[key] += cal.Quantity;
                }
                else
                {
                    calculation.Add(key, cal.Quantity);
                }
            }

            List<Book> topBooks = new List<Book>();
            int check = 0;
            foreach (var item in calculation.OrderByDescending(key => key.Value))
            {
                int x = item.Key;
                var b = DataAccessFactory.BookDataAccess().Get(x);

                topBooks.Add(b);
                check++;

                if(check == 5)
                {
                    break;
                }
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookModel>());
            var mapper = new Mapper(config);
            var topBooksModel = mapper.Map<List<BookModel>>(topBooks);



            return topBooksModel;
        }

    }
}

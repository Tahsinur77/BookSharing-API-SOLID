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
    public class OrderService
    {
        public static OrderModel Get(int orderId)
        {
            var order = DataAccessFactory.OrderDataAccess().Get(orderId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
            var mapper = new Mapper(config);
            var OrderModel = mapper.Map<OrderModel>(order);
            return OrderModel;
        }

        public static List<OrderModel> Get()
        {
            var orderList = DataAccessFactory.OrderDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
            var mapper = new Mapper(config);
            var orderModelList = mapper.Map<List<OrderModel>>(orderList);

            return orderModelList;

        }

        public static bool Add(OrderModel orderModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
            var mapper = new Mapper(config);
            var order = mapper.Map<Order>(orderModel);

            var check = DataAccessFactory.OrderDataAccess().Add(order);
            return check;
        }

        public static bool Edit(OrderModel orderModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
            var mapper = new Mapper(config);
            var order = mapper.Map<Order>(orderModel);

            var flag = DataAccessFactory.OrderDataAccess().Edit(order);
            return flag;
        }

        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.OrderDataAccess().Delete(id);
            return flag;
        }

    }
}

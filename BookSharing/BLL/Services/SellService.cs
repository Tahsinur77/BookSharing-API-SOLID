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
    public class SellService
    {
        public static SellModel Get(int orderId)
        {
            var sell = DataAccessFactory.SellDataAccess().Get(orderId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Sell, SellModel>());
            var mapper = new Mapper(config);
            var sellModel = mapper.Map<SellModel>(sell);
            return sellModel;
        }

        public static List<SellModel> Get()
        {
            var sellList = DataAccessFactory.SellDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Sell, SellModel>());
            var mapper = new Mapper(config);
            var sellModelList = mapper.Map<List<SellModel>>(sellList);

            return sellModelList;

        }

        public static bool Add(SellModel sellModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellModel, Sell>());
            var mapper = new Mapper(config);
            var sell = mapper.Map<Sell>(sellModel);

            var check = DataAccessFactory.SellDataAccess().Add(sell);
            return check;
        }

        public static bool Edit(SellModel sellModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellModel, Sell>());
            var mapper = new Mapper(config);
            var sell = mapper.Map<Sell>(sellModel);

            var flag = DataAccessFactory.SellDataAccess().Edit(sell);
            return flag;
        }

        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.SellDataAccess().Delete(id);
            return flag;
        }
        public static List<SellModel> SellSearch(SearchModel search)
        {

            var sellList = DataAccessFactory.SellDataSearch().Search(search.Search);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Sell, SellModel>());
            var mapper = new Mapper(config);
            var sellModel = mapper.Map<List<SellModel>>(sellList);

            return sellModel;
        }
    }
}

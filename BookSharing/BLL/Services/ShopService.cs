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
    public class ShopService
    {
        public static ShopModel Get(int shopId)
        {
            var news = DataAccessFactory.ShopDataAccess().Get(shopId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopModel>());
            var mapper = new Mapper(config);
            var shopModel = mapper.Map<ShopModel>(news);

            return shopModel;
        }

        public static List<ShopModel> Get()
        {
            var shopList = DataAccessFactory.ShopDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopModel>());
            var mapper = new Mapper(config);
            var shopModelList = mapper.Map<List<ShopModel>>(shopList);

            return shopModelList;

        }

        public static bool Add(ShopModel shopModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopModel, Shop>());
            var mapper = new Mapper(config);
            var shop = mapper.Map<Shop>(shopModel);

            var check = DataAccessFactory.ShopDataAccess().Add(shop);
            return check;
        }

        public static bool Edit(ShopModel shopModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopModel, Shop>());
            var mapper = new Mapper(config);
            var shop = mapper.Map<Shop>(shopModel);

            var flag = DataAccessFactory.ShopDataAccess().Edit(shop);
            return flag;
        }

        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.ShopDataAccess().Delete(id);
            return flag;
        }
    }
}

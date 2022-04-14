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
    public class ShopChangeRequestService
    {
        public static ShopChangeRequestModel Get(int shopId)
        {
            var shopDetails = DataAccessFactory.ShopChangeRequestDataAccess().Get(shopId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopChangeRequest, ShopChangeRequestModel>());
            var mapper = new Mapper(config);
            var shopDetailsModel = mapper.Map<ShopChangeRequestModel>(shopDetails);
            return shopDetailsModel;
        }
        public static List<ShopChangeRequestModel> Get()
        {
            var shopDetailsList = DataAccessFactory.ShopChangeRequestDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopChangeRequest, ShopChangeRequestModel>());
            var mapper = new Mapper(config);
            var shopDetailsModelList = mapper.Map<List<ShopChangeRequestModel>>(shopDetailsList);

            return shopDetailsModelList;

        }
        public static bool Add(ShopChangeRequestModel shopChangeRequestsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopChangeRequestModel, ShopChangeRequest>());
            var mapper = new Mapper(config);
            var shop = mapper.Map<ShopChangeRequest>(shopChangeRequestsModel);

            var check = DataAccessFactory.ShopChangeRequestDataAccess().Add(shop);
            return check;
        }

        public static bool Edit(ShopChangeRequestModel shopChangeRequestModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShopChangeRequestModel, ShopChangeRequest>());
            var mapper = new Mapper(config);
            var shop = mapper.Map<ShopChangeRequest>(shopChangeRequestModel);

            var flag = DataAccessFactory.ShopChangeRequestDataAccess().Edit(shop);
            return flag;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.ShopChangeRequestDataAccess().Delete(id);
            return flag;
        }
    }
}

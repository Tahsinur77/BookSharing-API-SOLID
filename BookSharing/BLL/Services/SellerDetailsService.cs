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
    public class SellerDetailsService
    {
        public static SellerDetailsModel Get(int sellerId)
        {
            var sellerDetails = DataAccessFactory.SellerDetailsDataAccess().Get(sellerId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerDetails, SellerDetailsModel>());
            var mapper = new Mapper(config);
            var sellerDetailsModel = mapper.Map<SellerDetailsModel>(sellerDetails);
            return sellerDetailsModel;
        }
        public static List<SellerDetailsModel> Get()
        {
            var sellerDetailsList = DataAccessFactory.SellerDetailsDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerDetails, SellerDetailsModel>());
            var mapper = new Mapper(config);
            var sellerDetailsModelList = mapper.Map<List<SellerDetailsModel>>(sellerDetailsList);

            return sellerDetailsModelList;

        }
        public static bool Add(SellerDetailsModel sellerDetailsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerDetailsModel, SellerDetails>());
            var mapper = new Mapper(config);
            var seller = mapper.Map<SellerDetails>(sellerDetailsModel);

            var check = DataAccessFactory.SellerDetailsDataAccess().Add(seller);
            return check;
        }

        public static bool Edit(SellerDetailsModel sellerDetailsModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerDetailsModel, SellerDetails>());
            var mapper = new Mapper(config);
            var seller = mapper.Map<SellerDetails>(sellerDetailsModel);

            var flag = DataAccessFactory.SellerDetailsDataAccess().Edit(seller);
            return flag;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.SellerDetailsDataAccess().Delete(id);
            return flag;
        }
    }
}

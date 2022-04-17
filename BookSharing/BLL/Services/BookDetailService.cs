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
    public class BookDetailService
    {
        public static BookDetailModel Get(int bdetailId)
        {
            var bdetail = DataAccessFactory.BookDetailDataAccess().Get(bdetailId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDetails, BookDetailModel>());
            var mapper = new Mapper(config);
            var bdetailModel = mapper.Map<BookDetailModel>(bdetail);

            return bdetailModel;
        }
        public static List<BookDetailModel> Get()
        {
            var bdetailList = DataAccessFactory.BookDetailDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDetails, BookDetailModel>());
            var mapper = new Mapper(config);
            var bdetailModelList = mapper.Map<List<BookDetailModel>>(bdetailList);

            return bdetailModelList;

        }
        public static bool Add(BookDetailModel bdetailModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDetailModel, BookDetails>());
            var mapper = new Mapper(config);
            var bdetail = mapper.Map<BookDetails>(bdetailModel);

            var check = DataAccessFactory.BookDetailDataAccess().Add(bdetail);
            return check;
            //return false;
        }

        public static bool Edit(BookDetailModel bdetailModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDetailModel, BookDetails>());
            var mapper = new Mapper(config);
            var bdetail = mapper.Map<BookDetails>(bdetailModel);

            var flag = DataAccessFactory.BookDetailDataAccess().Edit(bdetail);
            return flag;
            //return false;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.BookDetailDataAccess().Delete(id);
            return flag;
        }
    }
}

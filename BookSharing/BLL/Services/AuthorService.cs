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
    public class AuthorService
    {
        public static AuthorModel Get(int authorId)
        {
            var author = DataAccessFactory.AuthorDataAccess().Get(authorId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorModel>());
            var mapper = new Mapper(config);
            var authorModel = mapper.Map<AuthorModel>(author);

            return authorModel;
        }
        public static List<AuthorModel> Get()
        {
            var authorList = DataAccessFactory.AuthorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorModel>());
            var mapper = new Mapper(config);
            var authorModelList = mapper.Map<List<AuthorModel>>(authorList);

            return authorModelList;

        }
        public static bool Add(AuthorModel authorModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorModel, Author>());
            var mapper = new Mapper(config);
            var author = mapper.Map<Author>(authorModel);

            var check = DataAccessFactory.AuthorDataAccess().Add(author);
            return check;
        }

        public static bool Edit(AuthorModel authorModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorModel, Author>());
            var mapper = new Mapper(config);
            var author = mapper.Map<Author>(authorModel);

            var flag = DataAccessFactory.AuthorDataAccess().Edit(author);
            return flag;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.AuthorDataAccess().Delete(id);
            return flag;
        }
    }
}

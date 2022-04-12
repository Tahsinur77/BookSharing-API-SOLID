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
    public class UserService
    {
        public static UserModel Get(int userId)
        {
            var user = DataAccessFactory.UserDataAccess().Get(userId);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var userModel = mapper.Map<UserModel>(user);

            return userModel;
        }
        public static List<UserModel> Get()
        {
            var userList = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var userModelList = mapper.Map<List<UserModel>>(userList);

            return userModelList;

        }
        public static bool Add(UserModel userModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userModel);

            var check = DataAccessFactory.UserDataAccess().Add(user);
            return check;
        }

        public static bool Edit(UserModel userModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserModel, User>());
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userModel);

            var flag = DataAccessFactory.UserDataAccess().Edit(user);
            return flag;
        }
        public static bool Delete(int id)
        {
            var flag = DataAccessFactory.UserDataAccess().Delete(id);
            return flag;
        }

    }
}

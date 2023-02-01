using AutoMapper;
using FourmApplication.DataModel;
using FourmApplication.Repositary;
using FourmApplications.ViewModel.LoginAndRegisterViewModel;
using FourmApplications.ViewModel.UsersViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.ServiceLayer
{

    public interface Iservice
    {
        int InsertUser(RegisterViewModel rvm);
        void UpdateUserDetails(EditUserDetailsViewModel evm);
        void UpdateUserPassword(EditUserDetailsViewModel evm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUserByEmailAndPassword(string email, string password);
        UserViewModel GetUserByEmail(string email);
    }
    public class UsersService : Iservice
    {
        UsersRepositary _ur;
        public UsersService()
        {
            _ur = new UsersRepositary();
        }
        //private void CreateUserMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<UsersViewModel, Users>();
        //        cfg.IgnoreUnmapped();
        //    });
        //    IMapper mapper = config.CreateMapper();
        //    Users u = mapper.Map< Users>();
        //}
        public void DeleteUser(int uid)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<UsersViewModel, Users>();
            //    cfg.IgnoreUnmapped();
            //});
            //IMapper mapper = config.CreateMapper();
            //Users u = mapper.Map<Users>(uid);

            _ur.DeleteUser(uid);
        }

        public UserViewModel GetUserByEmail(string email)
        {
            Users u = _ur.GetUserEmail(email);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            });
            var mapper = config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users, UserViewModel>(u);
            return uvm;


        }

        public UserViewModel GetUserByEmailAndPassword(string email, string password)
        {
            Users u = _ur.GetUserEmailAndPassword(email, password);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users, UserViewModel>(u);
            return uvm;

        }

        public List<UserViewModel> GetUsers()
        {
            List<Users> users = new List<Users>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> u = mapper.Map<List<Users>, List<UserViewModel>>(users);
            _ur.GetUser();
            return u;
        }

        public int InsertUser(RegisterViewModel rvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<RegisterViewModel, Users>(rvm);
            _ur.InsertUser(u);
            return _ur.GetLatestUserId();

        }

        public void UpdateUserDetails(EditUserDetailsViewModel evm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserDetailsViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(evm);
            _ur.UpdateUser(u);

        }

        public void UpdateUserPassword(EditUserDetailsViewModel evm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserDetailsViewModel, Users>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Users u = mapper.Map<EditUserDetailsViewModel, Users>(evm);
            _ur.UpdatePassword(u);
        }

        UserViewModel Iservice.GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

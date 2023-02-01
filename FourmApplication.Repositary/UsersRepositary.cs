using FourmApplication.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmApplication.Repositary
{
    public interface IUsersRepositary
    {
        void InsertUser(Users u);
        void UpdateUser(Users u);   
        void UpdatePassword(Users u);   
        void DeleteUser(Users u);   
        List<Users> GetUser();
        Users GetUserEmailAndPassword(string email,string Password);
        Users GetUserEmail(string email);
        int GetLatestUserId();
    }
    public class UsersRepositary : IUsersRepositary
    {
        private FourmAppDBContext _dbContext;
        public UsersRepositary()
        {
            _dbContext = new FourmAppDBContext();   
        }
        public void DeleteUser(Users userId )
        {
           _dbContext.Users.Remove(_dbContext.Users.Find(userId));
            _dbContext.SaveChanges();    
        }

        public void DeleteUser(int uid)
        {
            throw new NotImplementedException();
        }

        public int GetLatestUserId()
        {
          Users u = _dbContext.Users.OrderByDescending(x => x.UserID).Take(1).FirstOrDefault();
            return u.UserID;
        }

        public List<Users> GetUser()
        {
          return  _dbContext.Users.ToList();
        }

        public Users GetUserEmail(string email)
        {
         return  _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public Users GetUserEmailAndPassword(string email, string Password)
        {
         Users user = _dbContext.Users.Where(x => x.Email == email && x.PasswordHash == Password).FirstOrDefault();
            return user;
        }

        public void InsertUser(Users u)
        {
            _dbContext.Users.Add(u);
            _dbContext.SaveChanges();
        }

        public void UpdatePassword(Users u)
        {
          Users user =  _dbContext.Users.Find(u.UserID);
            user.PasswordHash = u.PasswordHash;
            _dbContext.SaveChanges();
        }

        public void UpdateUser(Users u)
        {
            try
            {
                if(u != null && u.UserID > 0)
                {
                    Users user = _dbContext.Users.Where(x => x.UserID == u.UserID).FirstOrDefault();

                    if (user != null)
                    {
                        user.Name = u.Name;
                        user.Mobile = u.Mobile;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;   
            }
        }
    }
}

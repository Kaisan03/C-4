using DuAnBanGiayCs4.IServices;
using DuAnBanGiayCs4.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;

namespace DuAnBanGiayCs4.Services
{
    public class UserServices : IUserServices
    {
        ShopDbContext context;
        public UserServices()
        {
            context = new ShopDbContext();
        }
        public bool CreateUser(User us)
        {
            try
            {
                context.Users.Add(us);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var us = context.Users.Find(id);
                context.Users.Remove(us);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<User> GetAllUser()
        {
            return context.Users.Include("ChucVu").ToList();  
        }

        public User GetOneUser(string userName, string Pass)
        {
            return GetAllUser().Find(x => x.Email == userName && x.MatKhau == Pass);
        }

        public User GetUserById(Guid id)
        {
            return context.Users.Find(id);
        }

        public User GetUserByName(string name)
        {
            return context.Users.FirstOrDefault(x => x.Email == name);
        }

        public bool UpdateUser(User us)
        {
            try
            {
                var _user = context.Users.Find(us.Id);
                context.Users.Update(us);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

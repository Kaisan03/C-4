using DuAnBanGiayCs4.Models;

namespace DuAnBanGiayCs4.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User us);
        public bool UpdateUser(User us);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUser();
        public User GetUserById(Guid id);
        public User GetUserByName(string name);
        public User GetOneUser(string userName, string Pass);
    }
}

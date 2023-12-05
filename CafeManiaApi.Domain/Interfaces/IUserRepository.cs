
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserAll();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        User LoginUser(User user);

    }
}

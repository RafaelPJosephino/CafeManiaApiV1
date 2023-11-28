
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserAll();

        void RegisterUser(User user);
    }
}

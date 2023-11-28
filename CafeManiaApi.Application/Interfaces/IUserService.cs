using CafeManiaApi.Application.DTOs;

namespace CafeManiaApi.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUserAll();
        void RegisterUser(UserDTO user);
    }
}

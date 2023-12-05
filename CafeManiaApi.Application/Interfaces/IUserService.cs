using CafeManiaApi.Application.DTOs;

namespace CafeManiaApi.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUserAll();
        void AddUser(UserDTO user);
        void UpdateUser(UserDTO user);
        UserDTO LoginUser(UserDTO user);
    }
}

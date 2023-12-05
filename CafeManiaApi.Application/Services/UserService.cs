using AutoMapper;
using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManiaApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void AddUser(UserDTO user)
        {
            var User = new User(user.Name, user.Username, user.Email, user.Password, user.IsAdmin, user.Street, user.City, user.State, user.ZipCode);
            _userRepository.AddUser(User);
        }

        public void UpdateUser(UserDTO user)
        {
            var User = new User(user.Id, user.Name, user.Username, user.Email, user.Password, user.IsAdmin, user.Street, user.City, user.State, user.ZipCode);
            _userRepository.UpdateUser(User);
        }



        public IEnumerable<UserDTO> GetUserAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_userRepository.GetUserAll());
        }

        public UserDTO LoginUser(UserDTO user)
        {
            var User = _mapper.Map<User>(user);
            var UserLogin = _userRepository.LoginUser(User);
            var UserDTO =_mapper.Map<UserDTO>(UserLogin);
            return UserDTO;
             
        }
    }
}

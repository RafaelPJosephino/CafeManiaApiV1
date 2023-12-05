using CafeManiaApi.Domain.Entities;
using CafeManiaApi.Domain.Interfaces;
using CafeManiaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CafeManiaApi.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserAll()
        {
            return _context.User.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.User.Find(id) ?? throw new Exception($"Usuário não localizado com id {id}");
        }

        public void AddUser(User user)
        {
            if (_context.User
                .AsNoTracking()
                .Where(x => x.Email == user.Email)
                .Any())
            {
                throw new CustomAttributeFormatException("Email ja cadastrado");
            }

            _context.Add(user);
            _context.SaveChanges();
        }
        public User LoginUser(User user)
        {
            return _context.User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

    }
}

using backend.Database;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _context.Users.Select(user => user).ToList();

            return users;
        }

        public UserDto GetUserById(int id)
        {
            var result = _context.Users.FirstOrDefault(user => user.Id == id);

            return result;
        }

        public void AddUser(UserDto user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}

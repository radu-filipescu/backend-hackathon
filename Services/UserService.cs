using backend.Database;
using backend.DTOs;
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

        public void DeleteUser(int id)
        {
            var userDto = GetUserById(id);
            _context.Users.Remove(userDto);

            _context.SaveChanges();
        }

        public string GetUserRights(LoginDTO loginInfo)
        {
            var result = _context.Users.FirstOrDefault(user => user.Email == loginInfo.Email);

            if(result != null)
            {
                if (result.Password == loginInfo.Password)
                {
                    return "normal user";
                }
                else
                    return "not logged in";
            }
            else
            {
                var result2 = _context.Companies.FirstOrDefault(company => company.Email == loginInfo.Email);

                if (result2 != null)
                {
                    if (result2.Password == loginInfo.Password)
                    {
                        return "company admin";
                    }
                    else
                        return "not logged in";
                }
            }

            return "not logged in";
        }
    }
}

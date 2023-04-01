using backend.DTOs;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAllUsers();

        public UserDto GetUserById(int id);

        public void AddUser(UserDto user);

        public string GetUserRights(LoginDTO loginInfo);
    }
}

using backend.Services;
using Microsoft.AspNetCore.Mvc;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserDto> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _userService.ViewUserById( id );
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserDto user )
        {
            _userService.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

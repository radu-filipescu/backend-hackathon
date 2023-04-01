using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly string loginPath = "./loginStatus.txt";

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public SingleStringResponse GetUserStatus()
        {
            if (!System.IO.File.Exists(loginPath))
            {
                // Create the file.
                using (FileStream fs = System.IO.File.Create(loginPath))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("not logged");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            // Open the stream and read it back.
            using (StreamReader sr = System.IO.File.OpenText(loginPath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var result = new SingleStringResponse();

                    result.Value = s;
                    return result;
                }
            }


            return new SingleStringResponse("not logged in");
        }

        // POST api/<LoginController>
        [HttpPost]
        public SingleStringResponse Post([FromBody] LoginDTO loginInfo)
        {
            var result = new SingleStringResponse();
            
            result.Value = _userService.GetUserRights(loginInfo);

            System.IO.File.WriteAllText(loginPath, result.Value);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanetPals___backend.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public string Achievements { get; set; }
    }
}
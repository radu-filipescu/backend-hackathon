using backend.Database;
using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDBContext _context;

        public CompanyService(AppDBContext context)
        {
            _context = context;
        }

        public List<UserDto> ViewCompanies()
        {
            var users = _context.Companies.Select(user => user).ToList();

            return users;
        }

        public UserDto ViewCompanyById(int id)
        {

        }

        public void AddCompany(UserDto user)
        {

        }
    }
}

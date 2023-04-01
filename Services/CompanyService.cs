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

        public List<CompanyDto> GetCompanies()
        {
            var companies = _context.Companies.Select(user => user).ToList();

            return companies;
        }

        public CompanyDto GetCompanyById(int id)
        {
            var result = _context.Companies.FirstOrDefault(company => company.Id == id);

            return result;
        }

        public void AddCompany(CompanyDto company)
        {
            _context.Companies.Add(company);

            _context.SaveChanges();
        }
    }
}

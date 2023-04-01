using PlanetPals___backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface ICompanyService
    {
        public List<CompanyDto> GetCompanies();
        public CompanyDto GetCompanyById( int id );

        public void AddCompany(CompanyDto company);

        public void EditCompanyAchivments(int companyId, string newAchivements);
    }
}
